using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{

    private static CharacterManager _instance;

    public static CharacterManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CharacterManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
    public GameObject[] Characters;
    public int leader_indexer = 0;
    public GameObject selectedLeader;
    public GameObject indicator;
    public List<GameObject> myChars = new List<GameObject>();

    public List<GameObject> deadCharacaters = new List<GameObject>();
    public bool allDead = false;

    public Transform respawnPoint;

    public bool canSwitch;
    // Use this for initialization
    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform;
        canSwitch = false;
    }

    public void RemoveFromCharacterPool(GameObject character) //patayin
    {
        if (myChars.Count >= 1)
        {
            //moves selected leader to dead character pool
            character.GetComponent<Movements>().navmesh.enabled = false;
            character.GetComponent<Movements>().dead = true;
            character.GetComponent<Movements>().HP = 0;
            //character.transform.position = new Vector3(1000, 1000, 1000);

            if (character == myChars[myChars.Count - 1])
            {
                leader_indexer = 0;
            }

            deadCharacaters.Add(character);
            myChars.Remove(character);
            
        }

    }

    public void ReturnToCharacterPool() //ibalik
    {
        Debug.Log(deadCharacaters[0].name.ToString());
        deadCharacaters[0].GetComponent<Movements>().HP = deadCharacaters[0].GetComponent<Movements>().maxHp;
        deadCharacaters[0].GetComponent<Movements>().animator.SetTrigger("Alive");
        deadCharacaters[0].GetComponent<Movements>().dead = false;
        
        deadCharacaters[0].transform.position = respawnPoint.transform.position;
        deadCharacaters[0].GetComponent<Movements>().navmesh.enabled = true;
        //returns latest player who died back to character selection
        myChars.Add(deadCharacaters[0]);
        deadCharacaters.Remove(deadCharacaters[0]);
        

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Application.LoadLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Application.LoadLevel(1);
        }

        selectedLeader = myChars[leader_indexer];

        if(canSwitch)
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Change Leader"))
            {
                if (myChars.Count > 1)
                    leader_indexer += 1;
            }

        if (leader_indexer > myChars.Count - 1)
            leader_indexer = 0;

        indicator.transform.position = selectedLeader.transform.position - new Vector3(0, 1.5f, 0) ;

        if (myChars.Count == 0)
            allDead = true;
        if (allDead) Debug.Log("GG");

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            RemoveFromCharacterPool(selectedLeader);
        }

        if (Input.GetKeyDown(KeyCode.R)) //revive last person who died
        {
            ReturnToCharacterPool();

        }
    }
}
