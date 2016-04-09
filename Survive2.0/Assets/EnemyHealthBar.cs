using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

    UnityEngine.UI.Image image;
    AIScript enemy;
	void Start () 
    {
          image = GetComponent<UnityEngine.UI.Image>();
          enemy = GetComponentInParent<AIScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        image.fillAmount = enemy.curHealth / 100;
	}
}
