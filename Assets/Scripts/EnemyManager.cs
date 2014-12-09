using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 10f;
	public Transform[] spawnPoints;

    public GameObject golemParticleSpawner;

	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		/*
		if(playerHealth.currentHealth <= 0f)
		{
			return;
		}
		*/
		
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		
        Instantiate(golemParticleSpawner, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
