using UnityEngine;
using System.Collections;

public class Fighter_Skill3_Particle_Destroyer : MonoBehaviour {


    private bool ParticleDestroyer;
    public float ParticleTimer;

    // Use this for initialization
    void Start()
    {

        ParticleDestroyer = true;

        
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (ParticleDestroyer == true)
        {
            ParticleTimer += Time.deltaTime;

            if (ParticleTimer >= 2.7)
            {
                Destroy(gameObject);
            }

        }
    }
}
