using UnityEngine;
using System.Collections;

public class Level1Script : MonoBehaviour {

    SpawningScript spwnScript;
    float timeBetweenSpawns;
    float lastSpawnTime;
    GameObject player;
    public bool flameJetsActive;
    float mins;
    float secs;
    UnityEngine.UI.Text timer;
    float lastTime;
    PowerUpSpawner powerUpSpawner;
    bool hasSpawnedPowerUP;

	void Start () 
    {
        powerUpSpawner = GetComponent<PowerUpSpawner>();
        timer = GameObject.Find("Timer Text").GetComponent<UnityEngine.UI.Text>();
        mins = 5;
        secs = 0;
        player = GameObject.Find("Player");
        timeBetweenSpawns = 3;
        lastSpawnTime = 0;
        spwnScript = GetComponent<SpawningScript>();
        hasSpawnedPowerUP = false;
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (mins == 0 && secs == 0)
            Application.LoadLevel(3);

        if (mins == 0) Debug.Log("Game Over");
        if (secs == -1) { mins--; secs = 59; }
        if (secs < 10) timer.text = mins + ":0" + secs;
        else timer.text = mins + ":" + secs;

        //Activating and deactivating flame jets at set times.
        if (secs == 30) { flameJetsActive = true; if (!hasSpawnedPowerUP) { powerUpSpawner.SpawnPowerUp(); hasSpawnedPowerUP = true; } }
        if (secs == 0) { flameJetsActive = false; hasSpawnedPowerUP = false; }

        if (Time.timeSinceLevelLoad > lastSpawnTime + timeBetweenSpawns)
        {
            spwnScript.SpawnEnemy();
            lastSpawnTime = Time.timeSinceLevelLoad;
        }

        if (Time.timeSinceLevelLoad > lastTime + 1)
        {
            lastTime = Time.timeSinceLevelLoad;
            secs--;
        }
	}
}
