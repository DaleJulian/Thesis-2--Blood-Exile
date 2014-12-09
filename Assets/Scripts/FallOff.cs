using UnityEngine;
using System.Collections;

public class FallOff : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CharacterManager.instance.RemoveFromCharacterPool(col.gameObject);

        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
