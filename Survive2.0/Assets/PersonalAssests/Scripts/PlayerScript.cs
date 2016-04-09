using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    
    float maxHealth;
    public float curHealth;
    public bool canDie;
    Level1Script gameManager;
    UnityEngine.UI.Text healthText;
    UnityEngine.UI.Image healthBar;
    GunScript gun;
    float spikeDamageTimer;
    bool spikeDamage;
    bool poisoned;
    float poisonTimer;
    CharacterMotor motor;
    float normalSpeed;
    float runningSpeed;
    float slowSpeed;
    float lastTime;
    public bool running;
    float damageTimer;
    float soundBuffer;
    UnityEngine.UI.Image poisionImage;
    float lastDamageTime;
    public float shieldStrength;
    public bool shielded;
    UnityEngine.UI.Image shieldBar;
    UnityEngine.UI.Image damageBoost;

    void Start()
    {
        shielded = false;
        shieldStrength = 0;
        spikeDamage = true;
        spikeDamageTimer = 0;
        damageBoost = GameObject.Find("Damage Boost").GetComponent<UnityEngine.UI.Image>();
        gun = GameObject.Find("MachineGun_00").GetComponent<GunScript>();
        healthText = GameObject.Find("Health Text").GetComponent<UnityEngine.UI.Text>();
        healthBar = GameObject.Find("Health Bar").GetComponent<UnityEngine.UI.Image>();
        shieldBar = GameObject.Find("Shield Bar").GetComponent<UnityEngine.UI.Image>();
        maxHealth = 100;
        curHealth = maxHealth;
        canDie = true;
        gameManager = GameObject.Find("Game Manager").GetComponent<Level1Script>();
        poisoned = false;
        poisonTimer = 0;
        motor = GetComponentInParent<CharacterMotor>();
        normalSpeed = 6;
        runningSpeed = 10;
        slowSpeed = 3;
        lastTime = 0.0f;
        running = false;
        damageTimer = 0;
        lastDamageTime = 0;
        soundBuffer = 0;
        poisionImage = GameObject.Find("Poison Damage").GetComponent<UnityEngine.UI.Image>();
    }


    void Update()
    {
        soundBuffer -= 0.1f;
        if (curHealth > maxHealth) curHealth = maxHealth;
        if (Time.timeSinceLevelLoad >= spikeDamageTimer) spikeDamage = true;

        healthText.text = ""+curHealth;
        healthBar.fillAmount = curHealth / 100;


        shieldBar.fillAmount = shieldStrength / 100;

        if (shieldStrength > 0)
            shielded = true;
        else
            shielded = false;


        if (canDie)
        {
            if (curHealth <= 0)
            {
                Application.LoadLevel(4);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            running = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            running = false;


        if (damageTimer > 0)
        {
            if (Time.timeSinceLevelLoad >= lastDamageTime + 1)
            {
                damageTimer--;
                lastDamageTime = Time.timeSinceLevelLoad;
            }
            damageBoost.fillAmount = 1;
            gun.damage = 100;
        }
        else
        {
            damageBoost.fillAmount = 0;
            gun.damage = 50;
        }


        if (poisonTimer > 0)
        {
            Debug.Log("POISONED!" + poisonTimer);
            if (Time.timeSinceLevelLoad >= lastTime + 1)
            {
                poisonTimer--;
                lastTime = Time.timeSinceLevelLoad;
            }
            motor.movement.maxForwardSpeed = slowSpeed;
            motor.movement.maxBackwardsSpeed = slowSpeed;
            motor.movement.maxSidewaysSpeed = slowSpeed;
            poisionImage.fillAmount = 1;
        }
        else
        {
            poisionImage.fillAmount = 0;
            poisoned = false;
            if (running)
            {
                motor.movement.maxForwardSpeed = runningSpeed;
                motor.movement.maxBackwardsSpeed = runningSpeed;
                motor.movement.maxSidewaysSpeed = runningSpeed;   
            }
            else
            {
                motor.movement.maxForwardSpeed = normalSpeed;
                motor.movement.maxBackwardsSpeed = normalSpeed;
                motor.movement.maxSidewaysSpeed = normalSpeed;
            }
        }


    }
    void OnTriggerStay(Collider c)
    {
        Debug.Log("Stay");
        if (c.name == "FireDamageZone")
        {
            Debug.Log("Fire Damage");

            if (shielded)
                shieldStrength -= 0.1f;
            else
                curHealth -= 0.1f;

            if (soundBuffer <= 0)
            {
                soundBuffer = 3;
                GetComponentInParent<AudioSource>().Play();
            }
        }
        if (c.name == "FireJetDamageZone" && gameManager.flameJetsActive == true)
        {
            Debug.Log("Fire Damage");

            if (shielded)
                shieldStrength -= 0.1f;
            else
                curHealth -= 0.1f;

            if (soundBuffer <= 0)
            {
                soundBuffer = 3;
                GetComponentInParent<AudioSource>().Play();
            }
        }
        else if (c.name == "Poisin Pool Zone")
        {
            if (!poisoned)
            {
                poisoned = true;
                poisonTimer = 10;
                lastTime = Time.timeSinceLevelLoad;
            }
            if (soundBuffer <= 0)
            {
                soundBuffer = 3;
                GetComponentInParent<AudioSource>().Play();
            }
            if (shielded)
                shieldStrength -= 0.1f;
            else
                curHealth -= 0.1f;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.collider.name == "SpikeBall")
        {
            if (spikeDamage)
            {
                if (shielded)
                    shieldStrength -= 30;
                else
                    curHealth -= 30;
            }
            spikeDamageTimer = Time.timeSinceLevelLoad + 2;
            spikeDamage = false;
        }
    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Enter");
        if (c.name == "HealthPack(Clone)")
        {
            curHealth += 25;
            Destroy(c.gameObject);
        }
        if (c.name == "ShieldPowerUp(Clone)")
        {
            shieldStrength = 50;
            Destroy(c.gameObject);
        }
        if (c.name == "DamagePowerUp(Clone)")
        {
            damageTimer = 10;
            lastDamageTime = Time.timeSinceLevelLoad;
            Destroy(c.gameObject);
        }
        if (c.name == "Ammo(Clone)")
        {
            gun.ammo += 10;
            Destroy(c.gameObject);
        }
        if (c.name == "Bones(Clone)")
        {
            Debug.Log(c.collider.name);
            Destroy(c.gameObject);
        }
    }



}
