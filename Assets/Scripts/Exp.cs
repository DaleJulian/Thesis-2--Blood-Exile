using UnityEngine;
using System.Collections;

public class Exp : MonoBehaviour {

	float exp, totalexp;
	int curLevelmod;
	int level;
	float tempexp;

	// Use this for initialization
	void Start () {
		level = 1;
		exp = 0;
		curLevelmod = 1;
		totalexp = 150;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (exp > totalexp)
		{
			exp = 0;
			tempexp = totalexp;
			totalexp += tempexp * 0.7f;
			level +=1;
		}

		//Debug.Log ("Level = " + level + " Exp to Level = " + totalexp + " Exp = "+ exp);

		if(Input.GetKey(KeyCode.L))
		GainExp ();

	}

	void GainExp ()
	{
		exp += ((2 * Mathf.Pow (level, 3) + 9 * Mathf.Pow (level, 2) + 61 * level)/6);
	}





}
