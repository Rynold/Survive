using UnityEngine;
using System.Collections;

public class W03E04_ThrowingObjects : MonoBehaviour {
	
	public Rigidbody projectile; //the bullet object
	public Transform bulletSpawnPoint;
	public float speed = 20;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody tempProjectile = Instantiate(projectile, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody;
			
			//tempProjectile.velocity = bulletSpawnPoint.TransformDirection( new Vector3(0,0,speed));
			
			//adds force to world coordinates
			//tempProjectile.AddForce(new Vector3(0,0,speed), ForceMode.Impulse);
			
			//adds force relative to the object
			tempProjectile.AddRelativeForce(new Vector3(0,0,speed), ForceMode.Impulse);
			
			Physics.IgnoreCollision(tempProjectile.collider, bulletSpawnPoint.root.collider);
			
			//Calculate speed of a rigidbody
			//var bulletSpeed = Vector3.Dot(rigidbody.velocity, transform.forward);
		}
	
	}
}
