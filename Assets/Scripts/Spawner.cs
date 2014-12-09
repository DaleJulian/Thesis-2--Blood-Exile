using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public float spawnLimit, spawnIndex;
    public float rateOfSpawn = 3.0f;
    public float spawnTimer;

    public bool isNear;

    public GameObject[] enemiesToSpawn;
   
    private int randomSpawnIndex;
    
	// Use this for initialization
	void Start () {
        randomSpawnIndex = Random.Range(0, enemiesToSpawn.Length);
        
	}
	
    
	// Update is called once per frame
	void Update () {


        isNear = 
            (Vector3.Distance(this.gameObject.transform.position, 
            CharacterManager.instance.selectedLeader.transform.position) >= 10.0f)
            ?
            false : true;

        if (isNear)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnIndex < spawnLimit)
        {
            if (spawnTimer >= rateOfSpawn)
            {
                Instantiate(enemiesToSpawn[randomSpawnIndex], transform.position, transform.rotation);
                spawnIndex++;
                spawnTimer = 0;
                randomSpawnIndex = Random.Range(0, enemiesToSpawn.Length);
            }
        }
    }
}
