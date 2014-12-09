using UnityEngine;
using System.Collections;



public class MudGolem3 : MonoBehaviour {

	public GameObject Golem_ParticleDeath;
	public float HP;
	public float baseDmg;
	public float magicDmg;
	public float agi;
	public float def;
	
	public Experience exp;
	
	public GameObject hpbar;
	public GameObject expbar;
	public float maxHp;
	
	
	//public float wepDmg;
	public float dmgSkill;
	public float dmgAtk;
	public float skillType;
	public float skillDmg;
	public float skillTotal;
	public float currentDmg;
	
	public int skills = 2;
	public int type = 1;
	
	public int level = 1; 
	
	
	void EnemyType()
	{
		//Class
		switch (type) {
		case 1: //Mushroom Posion
		{
			HP = 10;
			def = 1;
			agi = 0;
			
			break;
		}
			
		case 2: //Mushroom Spikes
		{
			HP = 10;
			def = 1;
			agi = 0;
			magicDmg = 0;
			break;
		}
			
		case 3: //Taong Lupa
		{
			maxHp = 80; 
			HP = 80;
			baseDmg = 30;
			def = 6;
			agi = 0;
			magicDmg = 0;
			
			break;
		}
			
		case 4: //Rock
		{

			HP = 10;
			baseDmg = 255;
			def = 3;
			agi = 5;
			magicDmg = 0;
			
			break;	
		}
			
		case 5: //Ibon
		{
			HP = 10;
			baseDmg = 70;
			agi = 10;
			magicDmg = 0;
			
			break;	
		}
			
		case 6: //fireDwarf
		{
			HP = 30;
			baseDmg = 70;
			def = 8;
			agi = 10;
			magicDmg = 0;
			
			break;	
		}
			
		case 7: //earthDwarf
		{
			HP = 34;
			baseDmg = 40;
			def = 15;
			agi = 10;
			magicDmg = 20;
			
			break;	
		}
			
		case 8 : //bossDwarf
		{
			HP = 60;
			baseDmg = 100;
			def = 20;
			agi = 100;
			magicDmg = 40;
			
			break;
		}
		}
	}
	
	public void SkillDamage(int skilltype)
	{	int skill = skilltype;
		switch (skill) 
		{
			//Knight Skills
		case 1: //Blood Surge
		{	currentDmg = baseDmg;
			baseDmg = currentDmg + (baseDmg * 0.20f);
			break;
		}
		case 2: //Cyclone Pass
		{
			skillDmg = 10 + (agi * 0.25f);
			break;
		}
		case 3: //Defile Slash
		{
			skillDmg = (30 + (magicDmg * 0.30f) + (agi * 0.50f))/3;
			break;
		}
			
			//Fist Skills
		case 4: //Alacrity Spritz
		{
			skillDmg = 10 + (agi * 0.28f);
			break;
		}
		case 5: //Dynamic Jab
		{
			skillDmg = 15 + (magicDmg * 0.15f);
			break;
		}
		case 6: //Myriad Strike
		{
			skillDmg = 25 + (magicDmg * 0.40f) + (agi * 0.45f);
			break;
		}
			
			//Mage Skills
		case 7: //Gravel Swain
		{
			//Summon Golem0
			skillDmg = 5 + (magicDmg * 0.25f);
			break;
		}
		case 8: //Outburst
		{
			skillDmg = 8 + (magicDmg * 0.20f) + (agi * 0.09f);
			break;
		}
		case 9: //Alleviate Heal
		{
			skillDmg = 50 + (magicDmg * 0.55f);
			break;
		}
			
			//Hunter Skills
		case 10: //Daze Arrow
		{
			skillDmg = 30 + (magicDmg * 0.20f);
			break;
		}
		case 11: //Shaft
		{
			skillDmg = 60 + (agi * 0.35f);
			break;
		}
		case 12: //Rain Shower
		{
			skillDmg = 90 + (magicDmg * 0.35f) + (agi * 0.55f);
			break;
		}
			
		}
		
		dmgSkill = ((level + 2) * magicDmg + skillDmg)/4;
		
		//Debug.Log ("Skill Damage " + dmgSkill);
	}
	
	public float NormalDamage()
	{
		dmgAtk = ((level + 2)* 2 +baseDmg)/ 4 ;
		
		return dmgAtk;
		//Debug.Log ("Normal Damage : " + dmgAtk);
	} 
	
	public void inflictDamage(float dmg)
	{
		//Debug.Log ("HP: " + HP);
		HP -= dmg;
		//Debug.Log ("HP Left: " + HP);
	}
	
	// Use this for initialization
	void Start () {
		//hpbar = GameObject.FindGameObjectWithTag("EnemyHP");
		//hpbar.SetActive (true);
		EnemyType ();
		//SkillDamage (2);
		//NormalDamage ();
		//skills = 2;
	
		exp = GameObject.Find("Exp").GetComponent<Experience>();
		//dmgAtk = ((level + 2)* 2 +baseDmg)/ 4 ;
		expbar = GameObject.FindGameObjectWithTag("Exp");
	}
	
	// Update is called once per frame
	void Update () {
		if (HP < 0) {
			//hpbar.SetActive(false);
			Vector3 MudGolemPos = transform.position;
			Instantiate(Golem_ParticleDeath, MudGolemPos, Quaternion.Euler(0.0f, 0.0f, 0.0f));
			exp.GetComponent<Experience>().getExperience(50);


			Destroy(this.gameObject);
			
		}
	}
}
