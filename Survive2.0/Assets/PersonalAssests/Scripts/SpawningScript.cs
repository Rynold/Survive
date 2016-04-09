using UnityEngine;
using System.Collections;

public class SpawningScript : MonoBehaviour {

    public Object[] enemies;
    public GameObject[] spawnPoints;
    public bool canSpawn;

    public void SpawnEnemy()
    {
        if(canSpawn)
            Instantiate(enemies[Random.Range(0, 2)], spawnPoints[Random.Range(0, 6)].transform.position, Quaternion.identity);
    }
}
