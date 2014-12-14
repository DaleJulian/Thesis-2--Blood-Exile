using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] Transform player;
	//PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	public NavMeshAgent nav;
	
	
	
	[SerializeField]
	private Vector3 randomPosition; 
	public bool roam = true; 
	public GameObject Target;
	public float setNewRandomPoint;
	public float radius = 5.0f;
	
	public Animator anim;
	
	public float EnemyDamage;
	public bool dead;
	
	public Vector3 direction;
	
	public EnemyChar myHp;
	
	/*	public void Die()
	{
		Destroy (this.gameObject, 1);
	}*/
	
	void RoamAround()
	{
		if(setNewRandomPoint > 4.0f)
		{
			randomPosition = Random.insideUnitSphere * radius;
			randomPosition += transform.position;
			NavMeshHit hit;
			NavMesh.SamplePosition(randomPosition, out hit, radius, 1);
			Vector3 finalPosition = hit.position;
            nav.SetDestination(finalPosition);
			//if(nav.hasPath)
				
			setNewRandomPoint = 0;
			
		}
	}
	void Awake ()
	{
		//player = GameObject.FindGameObjectWithTag ("Player").transform;
		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		
		myHp = transform.gameObject.GetComponent<EnemyChar>();
	}
	
	void Start()
	{
		
		direction.Set(0, 0, 0);
		nav = GetComponent <NavMeshAgent> ();
		randomPosition = Random.insideUnitSphere * radius;
		anim = GetComponent<Animator> ();
		
		
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
				if(collide.gameObject.GetComponent<Movements>().HP > 0)
					target = collide.gameObject;
				
			}    
			
			if(target != null)
			{
				//Debug.Log(target.name);
				player = target.transform;
				nav.SetDestination(player.transform.position);
				
			}
			else
			{
				RoamAround();
				setNewRandomPoint += Time.deltaTime;
				
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
	
	void Attack(float delay)
	{
		player.GetComponent<Animator>().SetTrigger("Hurt");
	}
	
	void Update ()
	{
		anim.SetFloat("Speed", direction.sqrMagnitude);
		//dead = (myHp.HP <= 0) ? true : false;
		//dead = (myHp.HP <= 0) ? true : false;
		nav.enabled = (dead == false) ? true : false;
		
		if (player == null)
		{
			//print("Player null");
			SearchForTarget();
		}
		
		else if(player != null && player.tag == "Player")
		{
			Target = player.gameObject;
			nav.SetDestination(player.transform.position);
			transform.LookAt(player);
			int randomIndex = Random.Range(0, 10);
			if (Vector3.Distance(player.transform.position, this.transform.position) < 2.5f)
			{
				attackTimer += Time.deltaTime;

				randomIndex = Random.Range(0, 10);
				if(gameObject.name == "MudGolem 1" || 
                    gameObject.name == "MudGolem 1(Clone)" ||
                    gameObject.name == "MudGolem 2(Clone)" || 
                    gameObject.name == "MudGolem 3(Clone)")
				{
					if (attackTimer >= rate)
					{
						if (randomIndex < 3)
						{
							anim.SetTrigger("Attack");
							EnemyDamage = this.gameObject.GetComponent<MudGolem1>().NormalDamage();
							Target.gameObject.GetComponent<Movements> ().Hurt (EnemyDamage);
						}
						else if (randomIndex> 3  && randomIndex < 6)
						{
							anim.SetTrigger("Attack2");
							EnemyDamage = this.gameObject.GetComponent<MudGolem1>().NormalDamage();
							Target.gameObject.GetComponent<Movements> ().Hurt (EnemyDamage);
						}
						else if (randomIndex> 7  && randomIndex < 10)
						{
							anim.SetTrigger("Attack3");
							Target.gameObject.GetComponent<Movements> ().Hurt (100);
						}
						attackTimer = 0;
						randomIndex = Random.Range(1, 10);
					}
				}
				else if(player != null && player.tag == "Player")
				{
					if (attackTimer >= rate)
					{
						if (randomIndex < 2)
						{
							anim.SetTrigger("Spin");
							Target.gameObject.GetComponent<Movements> ().Hurt (100);
							//player.GetComponent<Animator>().SetTrigger("Hurt");
						}
						else if (randomIndex >= 2)
						{
							anim.SetTrigger("Attack");
							EnemyDamage = this.gameObject.GetComponent<EnemyChar>().NormalDamage();
							Target.gameObject.GetComponent<Movements> ().Hurt (EnemyDamage);
						}
						//player.GetComponent<Animator>().SetTrigger("Hurt");
						attackTimer = 0;
						randomIndex = Random.Range(1, 10);
						// StartCoroutine(PlayHurtWithDelay(0.2f));
					}
				}
				
			}
			
		}		
		else		
			player = null;
		
		//Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
		//if (Vector3.Distance(this.transform.position, player.transform.position) < 1.0f)
		//{
		//    Debug.Log("Malapit. PWede umatake.");
		//}
		//else
		//{
		//    Debug.Log("Malayo. Lapit ka muna");
		//}
		
		//else
		//{
		//    if (Vector3.Magnitude(player.transform.position - transform.position) > radius)
		//    {
		//        player = null;
		//    }
		//    else
		//    {
		//        transform.LookAt(player);
		//    }
		//}
		
		/*
		if (rigidbody.velocity.sqrMagnitude >= 1.1f)
			anim.SetFloat ("Speed", 1);
		else if (rigidbody.velocity.sqrMagnitude <= 1.0f)
			anim.SetFloat ("Speed", 0);
			*/
		if (nav.velocity.magnitude == 0)
		{
			anim.SetFloat("Speed", 0);
			
		}
		
		else if(nav.velocity.sqrMagnitude > 1)
		{
			anim.SetFloat("Speed", 1);
			//transform.rotation = Quaternion.LookRotation(characterManager.selectedLeader.transform.position * Time.deltaTime * 5.0f);
		}
		
	}
}
