using UnityEngine;
using System.Collections;

public class MudGolemSpawner : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;

    public GameObject mudgolemParticleSpawner;


    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
     

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(mudgolemParticleSpawner, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}