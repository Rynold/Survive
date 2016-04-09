using UnityEngine;
using System.Collections;

public class FlameMenuScript : MonoBehaviour {

    Light flameJetActiveLS;
    ParticleEmitter flameJetActiveIC;
    ParticleEmitter flameJetActiveOC;
    Light flameJetInactiveLS;
    ParticleEmitter flameJetInactiveOC;
    bool active;
    Level1Script lvlScript;
    // Use this for initialization
    void Start()
    {
        //lvlScript = GameObject.Find("Game Manager").GetComponent<Level1Script>();
        active = false;
        flameJetActiveLS = transform.FindChild("Flame").FindChild("Lightsource").GetComponent<Light>();
        flameJetActiveIC = transform.FindChild("Flame").FindChild("OuterCore").GetComponent<ParticleEmitter>();
        flameJetActiveOC = transform.FindChild("Flame").FindChild("InnerCore").GetComponent<ParticleEmitter>();
        flameJetInactiveLS = transform.FindChild("FlameWhileInactive").FindChild("Lightsource").GetComponent<Light>();
        flameJetInactiveOC = transform.FindChild("FlameWhileInactive").FindChild("OuterCore").GetComponent<ParticleEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        active = true;

        if (!active)
        {
            flameJetInactiveLS.enabled = true;
            flameJetInactiveOC.emit = true;
            flameJetActiveLS.enabled = false;
            flameJetActiveIC.emit = false;
            flameJetActiveOC.emit = false;
        }
        else
        {
            flameJetActiveLS.enabled = true;
            flameJetActiveIC.emit = true;
            flameJetActiveOC.emit = true;
        }
    }
}
