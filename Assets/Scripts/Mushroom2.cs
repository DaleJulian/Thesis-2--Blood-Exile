using UnityEngine;
using System.Collections;

public class Mushroom2 : MonoBehaviour {
	public GameObject life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.attachedRigidbody) {
			
			if(other.gameObject.tag == "Player")
			{
				//life = GameObject.FindGameObjectWithTag ("Hp");
				//life.GetComponent<PlayerHealth> ().TakeDamage (20);
                transform.localScale = new Vector3(1.36f, 1.36f, 1.36f);

				life = GameObject.Find ("Character Manager").GetComponent<CharacterManager> ().selectedLeader;
				//life.GetComponent<PlayerHealth> ().TakeDamage (0.1f);
				life.GetComponent<Movements>().Hurt(20);
			}
			
		}
		
	}
}
