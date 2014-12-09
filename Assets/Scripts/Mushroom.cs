using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
	public GameObject life;
    public GameObject MushroomPoison_Particles;
    private bool mushroomPoison_Active ;
    public float mushroomPoisonTimer;


	// Use this for initialization
	void Start () {

        MushroomPoison_Particles.GetComponent<ParticleSystem>().enableEmission = false;
	
	}
	
	// Update is called once per frame
	void Update () {



        if (mushroomPoison_Active == true)
        {
            MushroomPoison_Particles .GetComponent<ParticleSystem>().enableEmission = true;
            mushroomPoisonTimer += Time.deltaTime;

            if (mushroomPoisonTimer >= 5f)
            {
                mushroomPoison_Active = false;
            }

        }

        else if (mushroomPoison_Active == false)
        {
            MushroomPoison_Particles.GetComponent<ParticleSystem>().enableEmission = false;
            mushroomPoisonTimer = 0f;
        }

	}
	

    

	void OnTriggerStay(Collider other) 
	{

			if(other.gameObject.tag == "Player")
			{
                mushroomPoison_Active = true;
                          
						//life = GameObject.FindGameObjectWithTag ("Hp");
			life = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
						//life.GetComponent<PlayerHealth> ().TakeDamage (0.1f);
			life.GetComponent<Movements>().Hurt(0.1f);
			}
          

				
       
		
	}
}
