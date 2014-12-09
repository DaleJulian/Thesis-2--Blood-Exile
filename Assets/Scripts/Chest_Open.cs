using UnityEngine;
using System.Collections;

public class Chest_Open : MonoBehaviour {

    public Animator animator;
    public Manager inventory;
    public ItemDatabase database;
    private bool opened = false;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        inventory = GameObject.Find("Inventory Manager").GetComponent<Manager>();
        database = GameObject.Find("Item Database").GetComponent<ItemDatabase>();
	}


    void OnTriggerEnter(Collider col)
    {
        if (opened == false)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                opened = true;
                animator.SetTrigger("Open");
                inventory.StoreItem(Random.Range(0, database.itemFromDatabase.Count));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.X))
        {
//            Debug.Log("X");
            animator.SetTrigger("Open");
        }
	
	}
}
