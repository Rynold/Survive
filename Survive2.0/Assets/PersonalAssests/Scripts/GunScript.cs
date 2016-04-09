using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

    public GameObject bullet;
    Transform bulletSpawn;
    Animator anim;
    Ray ray;
    ParticleSystem pE;
    public float ammo;
    float maxAmmo;
    UnityEngine.UI.Text ammoText;
    UnityEngine.UI.Image ammoBar;
    public float damage;
    AudioSource shootingSound;

	void Start () 
    {
        bulletSpawn = GameObject.Find("BulletSpawn").transform;
        anim = GetComponent<Animator>();
        pE = GameObject.Find("Weapon Shoot Particle").GetComponent<ParticleSystem>();
        ammo = 50;
        damage = 50;
        ammoText = GameObject.Find("Ammo Text").GetComponent<UnityEngine.UI.Text>();
        ammoBar = GameObject.Find("Ammo Bar").GetComponent<UnityEngine.UI.Image>();
        shootingSound = GetComponent<AudioSource>();
        maxAmmo = 50;
	}
	
	void Update () 
    {
        ammoText.text = "" + ammo;

        if (ammo > maxAmmo)
            ammo = maxAmmo;

        ammoBar.fillAmount = ammo * 2 / 100;

        if (anim.GetBool("Shoot"))
        {
            anim.SetBool("Shoot", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            pE.enableEmission = true;
            if (ammo > 0)
            {
                Fire();
                shootingSound.Play();
                ammo--;
            }
        }
	}

    void Fire()
    {
        //anim.SetBool("Shoot", true);
        GameObject temp = (GameObject)Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        temp.GetComponent<BulletScript>().StartPersonal(bulletSpawn,damage);
    }
}
