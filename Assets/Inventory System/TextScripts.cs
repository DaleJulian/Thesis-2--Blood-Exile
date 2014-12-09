using UnityEngine;
using System.Collections;

public class TextScripts : MonoBehaviour {

    public Manager manager;
    private TextMesh text;

    public bool itemName, itemType, itemRarity, itemDesc, pageNumber;
	// Use this for initialization
	void Start () {

        manager = GameObject.Find("Page Manager").GetComponent<Manager>();
        text = gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

        if(pageNumber)
            text.text = "Page " + (manager.pageIndexer + 1) + " of 3";
        if (itemName)
        {
            if (manager.selectedSlot.item == null)
                text.text = "";
            else
                text.text = manager.selectedSlot.item.itemName.ToString();
        }
        if (itemType)
        {
            if (manager.selectedSlot.item == null)
                text.text = "";
            else
                text.text = "Type: " + manager.selectedSlot.item.itemType.ToString() ;
        }
        if (itemRarity)
        {
            if (manager.selectedSlot.item == null)
                text.text = "";
            else
                text.text = "Rarity: " + manager.selectedSlot.item.rarity.ToString();
        }

        if (itemDesc)
        {
            if (manager.selectedSlot.item == null)
                text.text = "";
            else
                text.text = "Description: " + manager.selectedSlot.item.itemDescription.ToString() ;
        }   
	}
}
