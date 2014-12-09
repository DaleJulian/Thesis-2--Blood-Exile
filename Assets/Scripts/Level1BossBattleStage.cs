using UnityEngine;
using System.Collections;

public class Level1BossBattleStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider others)
	{
		if(others.gameObject.tag == "Player" )
		{
			Application.LoadLevel("Level1FinalBoss");

		}
	}
}
