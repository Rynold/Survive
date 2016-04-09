using UnityEngine;
using System.Collections;

public class FireBallScript : MonoBehaviour {
    Vector3 vel;
	// Use this for initialization
	void Start () {
	    vel = new Vector3(0f,0f,0.2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.z <= -24 || gameObject.transform.position.z >= 1)
            vel = -vel;

        gameObject.transform.position += vel;

	}

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.name == "Player")
        {
            c.gameObject.GetComponent<PlayerScript>().curHealth -= 20;
            Destroy(gameObject);
        }
        
    }
}
