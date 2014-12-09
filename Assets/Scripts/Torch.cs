using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour
{
	public GameObject TorchFlames_Particle;
	public GameObject FirstPathBoss;
	public bool TorchFlame_Active;
	public bool isActive;
	public GameObject torchManager;
	
	// Use this for initialization
	void Start()
	{
		torchManager = GameObject.Find("TorchManager");
		TorchFlames_Particle.GetComponent<ParticleSystem>().enableEmission = false;
		
		FirstPathBoss.transform.GetChild(0).renderer.enabled = false;
		FirstPathBoss.collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.K))
            TorchFlame_Active = true;
		
		if (TorchFlame_Active == true)
		{
			TorchFlames_Particle.GetComponent<ParticleSystem>().enableEmission = true;
			FirstPathBoss.transform.GetChild(0).renderer.enabled = true;
			FirstPathBoss.collider.enabled = true;
            //TorchFlame_Active = false;
		}
		
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if(isActive == false)
			{	
				torchManager.GetComponent<TorchManager>().addTorch();
				TorchFlame_Active = true;
				isActive = true;
				
			}
		}
		
	}
}
