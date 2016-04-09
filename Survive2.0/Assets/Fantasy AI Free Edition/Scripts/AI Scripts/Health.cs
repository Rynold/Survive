using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float MaxHealth=100;
	public float CurrentHealth;
	public bool Dead;
	
	
	// Use this for initialization
	void Start () {
		//MAKE THE CURRENT HEALTH THE MAX HEALTH AT START
	CurrentHealth=MaxHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(CurrentHealth<=0)
        {
			CurrentHealth=0;
			Dead=true;
		}
	}
}
