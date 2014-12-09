using UnityEngine;
using System.Collections;

public class Slots : MonoBehaviour {

    public bool isTaken;
    public int itemCount;

    public Texture2D taken, empty;

    public Item item;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isTaken)
        {
            this.renderer.material.mainTexture = item.itemIcon;
            //this.renderer.material.mainTexture = Resources.Load<Texture2D>("Textures/Inventory Icons/" + item.itemName);
        }
        else
        {
            item = null;
            this.renderer.material.mainTexture = empty;

        }

        
	}
}
