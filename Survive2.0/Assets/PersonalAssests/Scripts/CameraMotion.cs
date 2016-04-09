using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {

    Vector3 pivote;
    float rotateSpeed;
	// Use this for initialization
	void Start () 
    {
        pivote = GameObject.Find("Pivot Point").transform.position;
        rotateSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        LookAt(pivote);
        transform.RotateAround(pivote, Vector3.up, rotateSpeed * Time.deltaTime);
	}

    void LookAt(Vector3 objPosition)
    {
        //Rotates the Enemies to look at the player. Because it moves the whole body as opposed to just the head
        Quaternion rotation = Quaternion.LookRotation(objPosition - transform.position);
        rotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
        transform.rotation = rotation;
    }
}
