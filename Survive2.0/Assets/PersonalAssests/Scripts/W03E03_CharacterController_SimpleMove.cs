using UnityEngine;
using System.Collections;

public class W03E03_CharacterController_SimpleMove : MonoBehaviour {
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	public float jumpSpeed = 8.0F;
	public CharacterController controller;
	
	// Use this for initialization
	void Start () 
	{
		//controller = GetComponent<CharacterController>();
	}
	
	
    void Update() 
	{
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        
		Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
		
		if (Input.GetButton("Jump"))
				forward.y = jumpSpeed;
		
		
        controller.SimpleMove(forward * curSpeed);
    }
}
