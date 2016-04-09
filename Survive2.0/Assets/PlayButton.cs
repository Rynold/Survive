using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    float timer = 2;
    float timerCountDown = 0;

    void Update()
    {
        if (timer <= 0)
            Application.LoadLevel(2);

        timer -= timerCountDown;
    }

    public void GoToLevel1()
    {
        GetComponent<AudioSource>().Play();

        timerCountDown = 1.0f/60.0f;
    }
}
