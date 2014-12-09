using UnityEngine;
using System.Collections;

public class Mage_HealPartyParticleDestroyer : MonoBehaviour {


    private bool Particle_Start;
    public float Particle_Timer;

	// Use this for initialization
	void Start () {

        Particle_Start = true;

	}
	
	// Update is called once per frame
    void Update()
    {

        if (Particle_Start == true) 
        {
            Particle_Timer += Time.deltaTime;
            if (Particle_Timer >= 6.0f)
            {
                Destroy(gameObject);
            }
        }

    }
}
