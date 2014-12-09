using UnityEngine;
using System.Collections;

public class Pages : MonoBehaviour {

    public Slots[] slots;
    public Manager manager;
    public Renderer children;
	// Use this for initialization
	void Start () {

        manager = GameObject.Find("Inventory Manager").GetComponent<Manager>();
	}

    // Update is called once per frame
    void Update()
    {

        if (manager.selectedPage != this)
        {
            foreach (Transform child in transform)
            {
                child.renderer.enabled = false;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.renderer.enabled = true;
            }
        }
	}
}
