using UnityEngine;
using System.Collections;

public class CollectibleScript : MonoBehaviour {

    float min;
    float max;
    float speed;

    void Start()
    {
        min = 2f;
        max = 3f;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= min)
            speed = -speed;
        if (transform.position.y >= max)
            speed = -speed;



        if (transform.name == "DamagePowerUp")
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
