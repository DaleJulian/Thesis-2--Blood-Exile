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
		
		if (Input.GetKeyDown (KeyCode.P) || Input.GetButtonDown("Open Inventory")) {
			Pause();}
	}
	
	void Pause()
	{
		canvas.enabled = !canvas.enabled;
		
	}
}
