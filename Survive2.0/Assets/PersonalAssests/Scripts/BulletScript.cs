using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    Quaternion rotation;
    float damage;
	void Start ()
    {
        
	}
    public void StartPersonal(Transform gun, float d)
    {
        damage = d;
        rotation = Quaternion.LookRotation(gun.forward);
        gameObject.transform.rotation = rotation;
        gameObject.rigidbody.AddRelativeForce(Vector3.forward * 40, ForceMode.Impulse);
    }
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Wall" || c.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (c.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            c.gameObject.GetComponent<AIScript>().curHealth -= damage;
        }
    }
}
