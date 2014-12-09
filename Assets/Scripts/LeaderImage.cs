﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderImage : MonoBehaviour {
	public GameObject leader;
	public RawImage LeaderIcon;
	public Texture LeaderTexture;
	// Use this for initialization
	public RawImage SkillUI1,SkillUI2,SkillUI3;
	public Texture Skill1Texture,Skill2Texture,Skill3Texture;

	void Start () {
		LeaderIcon = GetComponent<RawImage> ();
		SkillUI1 = GameObject.Find ("Skill1").GetComponent<RawImage> ();
		SkillUI2 = GameObject.Find ("Skill2").GetComponent<RawImage> ();
		SkillUI3 = GameObject.Find ("Skill3").GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		//leader = GameObject.Find("Character Manager").GetComponent<CharacterManager>().leader_indexer;
		leader = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
		LeaderPortrait (leader);
		LeaderIcon.texture = LeaderTexture;
		SkillUI1.texture = Skill1Texture;
		SkillUI2.texture = Skill2Texture;
		SkillUI3.texture = Skill3Texture;
	}

	void LeaderPortrait(GameObject type){

		switch (type.gameObject.name) {
		case "Knight": {//Knight
			LeaderTexture = Resources.Load<Texture>("Knight_Portrait");
			Skill1Texture = Resources.Load<Texture>("Skill1_Knight");
            Skill2Texture = Resources.Load<Texture>("Skill2_Knight");
            Skill3Texture = Resources.Load<Texture>("Skill3_Knight");
			break;
		}
			
		case "Fighter": {//Fighter
			LeaderTexture = Resources.Load<Texture>("Fist_Portrait");
            Skill1Texture = Resources.Load<Texture>("Skill1_Fighter");
            Skill2Texture = Resources.Load<Texture>("Skill2_Fighter");
            Skill3Texture = Resources.Load<Texture>("Skill3_Fighter");
			break;
		}
			
		case "Mage": {//Mage
			LeaderTexture = Resources.Load<Texture>("Mage_Portrait");
            Skill1Texture = Resources.Load<Texture>("Skill1_Mage");
            Skill2Texture = Resources.Load<Texture>("Skill2_Mage");
            Skill3Texture = Resources.Load<Texture>("Skill3_Mage");
			break;
		}
			/*
			switch (type) {
			case 0: {//Knight
				LeaderTexture = Resources.Load<Texture>("Knight");
				Skill1Texture = Resources.Load<Texture>("Knight");
				Skill2Texture = Resources.Load<Texture>("Knight");
				Skill3Texture = Resources.Load<Texture>("Knight");
				break;
			}
				
			case 1: {//Fighter
				LeaderTexture = Resources.Load<Texture>("fighter");
				Skill1Texture = Resources.Load<Texture>("fighter");
				Skill2Texture = Resources.Load<Texture>("fighter");
				Skill3Texture = Resources.Load<Texture>("fighter");
				break;
			}
				
			case 2: {//Mage
				LeaderTexture = Resources.Load<Texture>("Mage");
				Skill1Texture = Resources.Load<Texture>("Mage");
				Skill2Texture = Resources.Load<Texture>("Mage");
				Skill3Texture = Resources.Load<Texture>("Mage");
				break;
			}
			*/
		}

	}
}
