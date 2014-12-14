using UnityEngine;
using System.Collections;

public class ControlsCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (CharacterManager.instance.canSwitch)
            if (Input.GetButtonDown("Open Inventory") || Input.GetKeyDown(KeyCode.Return))
                GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
	}
}
