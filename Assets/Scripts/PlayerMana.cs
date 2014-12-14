using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMana : MonoBehaviour
{
	public int startingMana = 100;
	
	public float currentMana;
	public Slider manaSlider;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public GameObject Player;
	public int PlayerType;
	
	Animator anim;
	AudioSource playerAudio;
	
	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		
		playerAudio = GetComponent <AudioSource> ();
		manaSlider = GetComponent<Slider>();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		manaSlider.maxValue = 100;
		currentMana = startingMana;

		//currentHealth = 
	}
	
	void Start()
	{
		Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
        if (Player != null)
            manaSlider.maxValue = Player.GetComponent<Movements> ().Mana;
	}
	
	void Update ()
	{
		
				if (PlayerType == 0) {	
						Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
			
						switch (Player.gameObject.name) {
				
						case "Knight":
								{
				
										//Player = GameObject.Find("Knight");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
										break;
								}
				
						case "Fighter":
								{
										// = GameObject.Find("Fighter");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
										break;
								}
				
						case "Mage":
								{ 
										//Player = GameObject.Find("Mage");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
										break;
								}
				
						}
				} else if (PlayerType == 1) {	
						Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
			
						switch (Player.gameObject.name) {
				
						case "Knight":
								{
										Player = GameObject.Find ("Fighter");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
			
										break;
								}
				
						case "Fighter":
								{
										Player = GameObject.Find ("Mage");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
										break;
								}
				
						case "Mage":
								{ 
										Player = GameObject.Find ("Knight");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
										break;
								}
				
						}
				} else if (PlayerType == 2) {	
						Player = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
			
						switch (Player.gameObject.name) {
				
						case "Knight":
								{
										Player = GameObject.Find ("Mage");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
				
										break;
								}
				
						case "Fighter":
								{
										Player = GameObject.Find ("Knight");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
				
										break;
								}
				
						case "Mage":
								{ 
										Player = GameObject.Find ("Fighter");
										manaSlider.maxValue = Player.GetComponent<Movements> ().maxMana;	
										manaSlider.value = currentMana;
										currentMana = Player.GetComponent<Movements> ().Mana;
				
										break;
								}
				
						}
				}
	
		}
	
	
	
	public void RegenMana(float amount)
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
	
	
}
