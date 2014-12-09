using UnityEngine;
using System.Collections;

public class GolemParticleDestroyer : MonoBehaviour {

    public float golemParticleTimer;
    private bool golemParticleActive;

	// Use this for initialization
	void Start () {

        golemParticleActive = true;
      //  golemParticleTimer += Time.deltaTime;

	}
	
	// Update is called once per frame
    void Update()
    {

        if (golemParticleActive == true)
        {
            golemParticleTimer += Time.deltaTime;
        }

        if (golemParticleTimer >= 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
