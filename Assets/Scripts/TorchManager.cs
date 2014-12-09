using UnityEngine;
using System.Collections;

public class TorchManager : MonoBehaviour {
	public int torchCount;
	// Use this for initialization
	void Start () {
		torchCount = 0;
	}

	public void addTorch()
	{
		torchCount += 1;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
