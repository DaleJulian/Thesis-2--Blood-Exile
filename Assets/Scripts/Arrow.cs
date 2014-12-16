using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public float baseDmg, def, agi, magicDmg, dmgAtk;
	// Use this for initialization
	public int level = 1;

	void Start () {
		baseDmg = 35.0f;
		NormalDamage ();
	}

	public float NormalDamage()
	{
		dmgAtk = ((level + 2) * 2 + baseDmg) / 4;
		return dmgAtk;
		//Debug.Log ("Normal Damage : " + dmgAtk);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			col.gameObject.GetComponent<Movements>().Hurt(dmgAtk);
			Destroy(this.gameObject);
		}
	}
}
