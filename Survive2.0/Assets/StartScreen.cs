using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

    float timer = 3;
	void Update () 
    {
        //This will ensure that the player cant click to change levels until 3 seconds are up.
        if (Time.timeSinceLevelLoad > timer)
        {
            if (Input.anyKey)
                Application.LoadLevel(1);
        }
	}
}
