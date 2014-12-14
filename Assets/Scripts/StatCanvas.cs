using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StatCanvas : MonoBehaviour {
	Canvas canvas;
	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(CharacterManager.instance.canSwitch)
		    if (Input.GetKeyDown (KeyCode.P) || Input.GetButtonDown("Open Inventory") || Input.GetKeyDown(KeyCode.Return)) {
			    Pause();}
	}
	
	void Pause()
	{
		canvas.enabled = !canvas.enabled;
		
	}
}
