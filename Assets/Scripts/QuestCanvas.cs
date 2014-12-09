using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestCanvas : MonoBehaviour {
	public Text count;
	public GameObject torchManager, countobject;
	public int value;
	Canvas canvas;
	// Use this for initialization

	void Start () {
		canvas = GetComponent<Canvas> ();

		torchManager = GameObject.Find("TorchManager");
		countobject = GameObject.Find("Count");
		count = countobject.GetComponent<Text>();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		value = torchManager.GetComponent<TorchManager> ().torchCount;
		count.text = value.ToString ();

		if (Input.GetKeyDown (KeyCode.Q)) {
			Pause();}

        if (Input.GetButtonDown("Open Inventory"))
            canvas.enabled = !canvas.enabled;
        
	}

	void Pause()
	{
		canvas.enabled = !canvas.enabled;
	}
}
