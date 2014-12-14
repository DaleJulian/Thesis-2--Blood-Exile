using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public float currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public GameObject Player;
	public int PlayerType;
	public RawImage SubChar1, SubChar2;
	public Texture SubCTexture1, SCT;
	public Texture SubCTexture2;
	
	Animator anim;
	AudioSource playerAudio;
	
	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
		SubChar1 = GameObject.Find ("Character image 1").GetComponent<RawImage> ();
		SubChar2 = GameObject.Find ("Character image 2").GetComponent<RawImage> ();


		anim = GetComponent <Animator> ();
		
		playerAudio = GetComponent <AudioSource> ();
		
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
		//currentHealth = 
	}
	
	void Start()
	{
		SubChar1 = GameObject.Find ("Character image 1").GetComponent<RawImage> ();
		SubChar2 = GameObject.Find ("Character image 2").GetComponent<RawImage> ();
		Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
		if(Player != null)
            healthSlider.maxValue = Player.GetComponent<Movements>().maxHp;
	}
	
	void Update ()
	{
		SubChar1.texture = SubCTexture1;
		SubChar2.texture = SubCTexture2;

		//healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
		
		if (PlayerType == 0) {	
						Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;

						switch (Player.gameObject.name) {

						case "Knight":
								{

										//Player = GameObject.Find("Knight");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
										currentHealth = Player.GetComponent<Movements> ().HP;
										break;
								}

						case "Fighter":
								{
										// = GameObject.Find("Fighter");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
			
			
										currentHealth = Player.GetComponent<Movements> ().HP;
										break;
								}

						case "Mage":
								{ 
										//Player = GameObject.Find("Mage");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
										currentHealth = Player.GetComponent<Movements> ().HP;
										break;
								}
			
						}
				}

			else if (PlayerType == 1) {	
						Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
			
						switch (Player.gameObject.name) {
				
						case "Knight":
								{
										Player = GameObject.Find ("Fighter");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
										currentHealth = Player.GetComponent<Movements> ().HP;
										SubCTexture1= Resources.Load<Texture>("Fist_Portrait");
										SubCTexture2= Resources.Load<Texture>("Mage_Portrait");
										break;
								}
				
						case "Fighter":
								{
										Player = GameObject.Find ("Mage");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
										currentHealth = Player.GetComponent<Movements> ().HP;
										SubCTexture1= Resources.Load<Texture>("Mage_Portrait");	
										SubCTexture2= Resources.Load<Texture>("Knight_Portrait");
										break;
								}
				
						case "Mage":
								{ 
										Player = GameObject.Find ("Knight");
										healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
										healthSlider.value = currentHealth;
										currentHealth = Player.GetComponent<Movements> ().HP;
										SubCTexture1= Resources.Load<Texture>("Knight_Portrait");
										SubCTexture2= Resources.Load<Texture>("Fist_Portrait");
										break;
								}
				
						}
				}

			else if (PlayerType == 2) {	
				Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
				
				switch (Player.gameObject.name) {
					
				case "Knight":
				{
					Player = GameObject.Find("Mage");
					healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
					healthSlider.value = currentHealth;
					currentHealth = Player.GetComponent<Movements> ().HP;
					SubCTexture2= Resources.Load<Texture>("Mage_Portrait");

					break;
				}
					
				case "Fighter":
				{
					Player = GameObject.Find("Knight");
					healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
					healthSlider.value = currentHealth;
					currentHealth = Player.GetComponent<Movements> ().HP;
					SubCTexture2= Resources.Load<Texture>("Knight_Portrait");
		
					break;
				}
					
				case "Mage":
				{ 
					Player = GameObject.Find("Fighter");
					healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
					healthSlider.value = currentHealth;
					currentHealth = Player.GetComponent<Movements> ().HP;
					SubCTexture2= Resources.Load<Texture>("Fist_Portrait");
			
					break;
				}
					
				}
		}

		/*
		switch(PlayerType){
		case 0:
			{
				Player = GameObject.Find("Knight");
				healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
				healthSlider.value = currentHealth;
				currentHealth = Player.GetComponent<Movements>().HP;
				break;
			}
		case 1:
			{
			Player = GameObject.Find("Fighter");
				healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
				healthSlider.value = currentHealth;
				
				
				currentHealth = Player.GetComponent<Movements>().HP;
				break;
			}
		case 2:
			{
			Player = GameObject.Find("Mage");
				healthSlider.maxValue = Player.GetComponent<Movements> ().maxHp;
				healthSlider.value = currentHealth;
				currentHealth = Player.GetComponent<Movements>().HP;
				break;
			}

		}
		*/
		
		/*
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		*/
		damaged = false;
		
		if (Input.GetKeyDown (KeyCode.B)) {
			//TakeDamage(20);
			Player.GetComponent<Movements>().Hurt(20);
		}
	}
	
	
	public void TakeDamage (float amount)
	{
		
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		//playerAudio.Play ();
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	public void RegenHP(float amount)
	{
		/*
		if ((currentHealth + amount) < healthSlider.maxValue) {
						currentHealth += amount; 
						healthSlider.value = currentHealth;
		} else if ((currentHealth + amount) > healthSlider.maxValue) { 
				healthSlider.value = healthSlider.maxValue;
		}
		*/
	}
	
	
	void Death ()
	{
		isDead = true;
		
		//playerShooting.DisableEffects ();
		
		anim.SetTrigger ("Die");
		
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		
		
		//playerShooting.enabled = false;
	}
}
