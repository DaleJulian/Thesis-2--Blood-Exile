using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

    public Pages[] page;
    public Pages selectedPage;
    public Slots selectedSlot;
    public GameObject[] slotBackground;
    public int pageIndexer, slotIndexer = 0;

    public ItemDatabase itemDatabase;

    public GameObject highlighter;

    public bool isEnabled;
    public Vector3 velocity;
    public Transform from, to;

    // Use this for initialization
    void Start()
    {
        isEnabled = false;
        itemDatabase = GameObject.Find("Item Database").GetComponent<ItemDatabase>();
        slotIndexer = 0;
    }

    public bool isTrigger;


    void SlotSelection()
    {
        Vector3 moveDir;
        moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        selectedPage = page[pageIndexer];
        selectedSlot = selectedPage.slots[slotIndexer];
        highlighter.transform.position = selectedSlot.transform.position + new Vector3(0, 0, 1);


        //if (Input.GetButtonDown("Inventory_Horizontal"))
        //{
        //    Debug.Log("Invn");
        //}

        //implement http://answers.unity3d.com/questions/63048/can-you-use-an-axis-to-navigate-a-selection-grid-e.html
        

        if(isTrigger == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                slotIndexer += 1;
                isTrigger = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                slotIndexer -= 1;
                isTrigger = true;
            }
            if (Input.GetAxis("Vertical") >= 0.1)
            {
                
                slotIndexer -= 4;
                isTrigger = true;
            }

            if (Input.GetAxis("Vertical") <= -0.1 )
            {
                
                slotIndexer += 4;
                isTrigger = true;
            }
            
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            isTrigger = false;
        }

        

        //if (Input.GetAxis("Inventory_Horizontal") < 0)
        //{
        //    slotIndexer-=1;
        //}

        //

        if (slotIndexer > 0)
        {
            if (slotIndexer > 4)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    slotIndexer -= 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                slotIndexer--;
            }
        }
        if (slotIndexer < 20)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                slotIndexer++;
            }
            //if (slotIndexer < 6)
            //{
                if (Input.GetKeyDown(KeyCode.S))
                {
                    slotIndexer += 4;
                }
            //}
        }
    }

    public void StoreItem(int _itemID)
    {
        
        bool hasFoundEmptySlot = false;
        for (int i = 0; i < page.Length; i++) //check for pages
        {
            for (int j = 0; j < page[i].slots.Length; j++) //check for slots
            {
                if (page[i].slots[j].isTaken == false) //if (page[i].slots[j].item == null)
                {
                    hasFoundEmptySlot = true;
                    for (int k = 0; k < itemDatabase.itemFromDatabase.Count; k++)
                    {
                        if (itemDatabase.itemFromDatabase[k].itemID == _itemID) //checks if id is in the database
                        {
                            page[i].slots[j].item = itemDatabase.itemFromDatabase[_itemID];
                            page[i].slots[j].isTaken = true;
                        }
                    }
                    break;
                }
            }
            if (hasFoundEmptySlot)
                break;
        }
        if (!hasFoundEmptySlot)
        {
            print("Inventory full.");
        }

    }

    void ClearInventory()
    {
        for (int i = 0; i < page.Length; i++)
        {
            for (int j = 0; j < page[i].slots.Length; j++)
            {
                if (page[i].slots[j].isTaken)
                {
                    page[i].slots[j].item = null;
                    page[i].slots[j].isTaken = false;
                }
            }

        }
    }

    void Shopping()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            StoreItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            StoreItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            StoreItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            StoreItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            StoreItem(4);
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            StoreItem(5);
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            StoreItem(6);
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            StoreItem(7);
        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
            StoreItem(8);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Open Inventory"))
        {
            isEnabled = !isEnabled;
        }
        if (isEnabled)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, to.position, ref velocity, 0.3f);
        }
        else
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, from.position, ref velocity, 0.3f);
        }


        if (isEnabled)
        {
            Shopping();
            SlotSelection();

            if (slotIndexer <= 0)
                slotIndexer = 0;
            if (slotIndexer > selectedPage.slots.Length - 1)
                slotIndexer = selectedPage.slots.Length - 1;

            if (Input.GetKeyDown(KeyCode.B))
            {
                StoreItem(Random.Range(0, itemDatabase.itemFromDatabase.Count));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (pageIndexer < page.Length - 1)
                    pageIndexer++;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (pageIndexer > 0)
                    pageIndexer--;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                selectedSlot.item = null;
                selectedSlot.isTaken = false;
            }
        }
        
    }
}
