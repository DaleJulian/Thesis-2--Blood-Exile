using UnityEngine;
using System.Collections;

public class Dwarf_Earth : MonoBehaviour {

	[SerializeField] Transform player;

	private NavMeshAgent navEarth;

	[SerializeField]

	public Animator animEarth;
	private Vector3 randomPosition; 
	public bool roam = true; 
	public GameObject Target;
	public float setNewRandomPoint;
	public float radius = 5.0f;

	public float EnemyDamage;

	public void Die()
	{
		Destroy (this.gameObject, 1);
	}

	// Use this for initialization
	void Start () {

		animEarth = GetComponent<Animator> ();
		navEarth = GetComponent <NavMeshAgent> ();
	
	}

	void SearchForTarget()
	{
		GameObject target = null;
		Collider[] col = Physics.OverlapSphere (transform.position, radius);
		
		foreach(Collider collide in col)
		{
			//float dist = Vector3.Distance(target.transform.position, transform.position);
			
			if (collide.gameObject.tag == "Player")
			{
				target = collide.gameObject;
				
			}    
			
			if(target != null)
			{
				Debug.Log(target.name);
				player = target.transform;
				navEarth.SetDestination(player.transform.position);
				
			}

		}
	}
	
	IEnumerator Attack()
	{
		
		yield return new WaitForSeconds(1.5f);
		
	}
	
	[SerializeField] float attackTimer, rate = 2.0f;
	
	
	
	
	IEnumerator PlayHurtWithDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		player.GetComponent<Animator>().SetTrigger("Hurt");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
		{
			//print("Player null");
			SearchForTarget();
		}
		
		else
		{	Target = player.gameObject;
			navEarth.SetDestination(player.transform.position);
			transform.LookAt(player);
			int randomIndex = Random.Range(0, 10);
			if (Vector3.Distance(player.transform.position, this.transform.position) < 2.5f)
			{
				attackTimer += Time.deltaTime;
				Debug.Log(Vector3.Distance(player.transform.position, transform.position));
				
				
				//randomIndex = Random.Range(0, 10);
				
				if (attackTimer >= rate)
				{
					if (randomIndex < 2)
					{
						animEarth.SetTrigger("Skill");
						Target.gameObject.GetComponent<Movements> ().Hurt (100);
						//player.GetComponent<Animator>().SetTrigger("Hurt");
					}
					else if (randomIndex >= 2)
					{
						animEarth.SetTrigger("Attack");
						EnemyDamage = this.gameObject.GetComponent<EnemyChar>().NormalDamage();
						Target.gameObject.GetComponent<Movements> ().Hurt (EnemyDamage);
					}
					//player.GetComponent<Animator>().SetTrigger("Hurt");
					attackTimer = 0;
					randomIndex = Random.Range(1, 10);
					StartCoroutine(PlayHurtWithDelay(0.2f));
				}
			}
			
			//Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
			//if (Vector3.Distance(this.transform.position, player.transform.position) < 1.0f)
			//{
			//    Debug.Log("Malapit. PWede umatake.");
			//}
			//else
			//{
			//    Debug.Log("Malayo. Lapit ka muna");
			//}
		}
	
	

	if (rigidbody.velocity.sqrMagnitude >= 1.1f)
		animEarth.SetFloat ("Speed", 1);
	else if (rigidbody.velocity.sqrMagnitude <= 1.0f)
		animEarth.SetFloat ("Speed", 0);
	}
}
