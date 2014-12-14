using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Skill 3") || Input.GetButtonDown("Open Inventory"))
        {
            Application.LoadLevel(0);
        }
	}

    IEnumerator returnToSomething()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
