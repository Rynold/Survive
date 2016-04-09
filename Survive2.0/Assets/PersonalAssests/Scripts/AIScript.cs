using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

    float distanceFromTarget;
    GameObject target;
    float lookAtDistance;
    float damping;
    float moveSpeed;
    float moveDistance;
    float attackDistance;
    float smoothingDistance;
    NavMeshAgent agent;
    Animation animation;
    bool dead;
    float maxHealth;
    public float curHealth;
    public GameObject[] drops;
    AudioSource deathSound;
    bool hasDropped;
    public AnimationClip RunAnimation;
    public AnimationClip IdleAnimation;
    public AnimationClip AttackAnimation;
    public AnimationClip DeathAnimation;
    bool doneDamage;
    float damageBuffer;
    float attackDamage;



	void Start () 
    {
        hasDropped = false;
        maxHealth = 100f;
        curHealth = maxHealth;
        dead = false;
        lookAtDistance = 30;
        damping = 10;
        moveSpeed = 7;
        moveDistance = 10;
        animation = gameObject.GetComponent<Animation>();
        animation.Play();
        attackDistance = 3;
        smoothingDistance = 5;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        deathSound = GetComponent<AudioSource>();
        doneDamage = false;
        damageBuffer = 1.1f;
        attackDamage = 10;
	}
	
	
	void Update () 
    {
        
        if (curHealth <= 0) dead = true;
        if (dead)
        {
            if (!hasDropped)
            {
                Vector3 dropPosition = new Vector3(transform.position.x,2.5f,transform.position.z);

                //Really bad 75% chance to drop something calculation.
                if (Random.Range(0, 100) < 75)
                {
                    //If the player has 10 or less ammo drop ammo. else drop random.
                    if (target.GetComponentInChildren<GunScript>().ammo <= 10)
                        Instantiate(drops[1], dropPosition, Quaternion.identity);
                    else
                        Instantiate(drops[Random.Range(0, drops.GetLength(0))], dropPosition, Quaternion.identity);
                }
                deathSound.Play();
                hasDropped = true;
            }
            Destroy(gameObject.rigidbody);
            Destroy(gameObject.collider);
            animation.clip = DeathAnimation;
            animation.Play();
            agent.SetDestination(transform.position);
            Destroy(gameObject, 2);
        }
        else
        {
            LookAt();
            //Gets the distance the Enemy is from the player than forces the enemy to look at the player.
            distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
            //Checks if the enemy is withing attacking distance, then checks movingDistance. If neither of
            //those statements evaluate as true, the enemy becomes idle.
            if (distanceFromTarget < attackDistance)
            {
                //Debug.Log("Is withing attack distance");
                animation.clip = AttackAnimation;
                animation.Play();
                attackDistance = 5.5f;
                agent.SetDestination(transform.position);

                if (!doneDamage)
                {
                    doneDamage = true;
                    damageBuffer = Time.timeSinceLevelLoad + 1.1f;
                    if (target.GetComponentInChildren<PlayerScript>().shielded)
                        target.GetComponentInChildren<PlayerScript>().shieldStrength -= attackDamage;
                    else
                        target.GetComponentInChildren<PlayerScript>().curHealth -= attackDamage;

                    target.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                attackDistance = 2;
                animation.clip = RunAnimation;
                animation.Play();
                agent.SetDestination(target.transform.position);
            }
            if (damageBuffer < Time.timeSinceLevelLoad) doneDamage = false;
        }
        
        
	}

    void LookAt()
    {
        //Rotates the Enemies to look at the player. Because it moves the whole body as opposed to just the head
        //I lock the rotation to just the y and w axis. Otherwise the enemies will be doing the limbo.
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
    }

    void MoveTowardsTarget()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
