using UnityEngine;
using System.Collections;

public class PathBoss : MonoBehaviour {

    private bool TorchIsLight;
    public GameObject TorchScript;




	// Use this for initialization
	void Start () {


        MeshRenderer MeshComponent = gameObject.GetComponent<MeshRenderer>();

        renderer.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {

        if (TorchIsLight == true)
        {
            renderer.enabled = true;
        }

	
	}
}
