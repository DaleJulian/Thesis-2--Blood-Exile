using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatManager : MonoBehaviour {
	Text statHP, statDef, statAgi, statBdmg, statMdmg;
	float value;
	string svalue;
	public GameObject player, HP, DEF, AGI, BDMG, MDMG;
	
	// Use this for initialization
	void Start () {



		HP = GameObject.Find("HP");
		DEF = GameObject.Find("DEF");
		AGI = GameObject.Find("AGI");
		BDMG = GameObject.Find ("BDMG");
		MDMG = GameObject.Find("MDMG");

		statHP = HP.GetComponent<Text>();
		statDef = DEF.GetComponent<Text>();
		statAgi = AGI.GetComponent<Text>();
		statBdmg = BDMG.GetComponent<Text>();
		statMdmg = MDMG.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		//player = GameObject.FindGameObjectWithTag("Leader");
		player = GameObject.Find("Character Manager").GetComponent<CharacterManager>().selectedLeader;


		if (HP.name == "HP") {
			value = player.GetComponent<Movements>().maxHp;
			statHP.text = value.ToString ();
		}
		
		
		if (DEF.name == "DEF") {
			value = player.GetComponent<Movements> ().def;
			
			statDef.text = value.ToString();
		}
		if (AGI.name == "AGI") {
			value= player.GetComponent<Movements> ().agi;
			statAgi.text = value.ToString();
		}
		
		if (BDMG.name == "BDMG") {
			value= player.GetComponent<Movements> ().baseDmg;
			statBdmg.text = value.ToString();
		}
		
		if (MDMG.name == "MDMG") {
			value= player.GetComponent<Movements> ().magicDmg;
			statMdmg.text = value.ToString();
		}
	}
}
