using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject[] powerUps;
    public Transform powerUpSpawner;
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPowerUp()
    {
        Instantiate(powerUps[Random.Range(0, 2)], powerUpSpawner.position, Quaternion.identity);
    }
}
