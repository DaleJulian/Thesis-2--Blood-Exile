using UnityEngine;
using System.Collections;

public enum SkeletonAIType
{
    Archer,
    Warrior
}

public class SkeletonAI : MonoBehaviour
{

    public SkeletonAIType SkeletonType;

    private NavMeshAgent navmeshAgent;
    private Vector3 randomPos;
    private bool roam;

    private Animator animator;
    public GameObject target;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private bool dead = false;
    [SerializeField]
    private float attackTimer;
    [SerializeField]
    private float rateOfAttack;
    [SerializeField]
    private float setRandomPointTimer;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float speed;
    [SerializeField]
    GameObject archerArrow;

    // Use this for initialization
    void Start()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        roam = false;

        navmeshAgent.stoppingDistance = (SkeletonType == SkeletonAIType.Archer)
            ? 15.0f : 5.0f;
        animator = GetComponent<Animator>();
        randomPos = Random.insideUnitSphere * radius;
        if (SkeletonType == SkeletonAIType.Archer)
        {
           
            
        }
    }

    private void RoamAround()
    {
        if (setRandomPointTimer > 5.0f)
        {
            randomPos = Random.insideUnitSphere * radius;
            randomPos += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomPos, out hit, radius, 1);
            Vector3 finalPosition = hit.position;

            if (navmeshAgent.hasPath)
                navmeshAgent.SetDestination(finalPosition);
            setRandomPointTimer = 0;
        }
    }

    private void SearchForTarget()
    {
        GameObject target = null;
        Collider[] col = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collide in col)
        {
            if (collide.gameObject.tag == "Player")
            {
                if (collide.gameObject.GetComponent<Movements>().HP > 0)
                    target = collide.gameObject;
            }

            if (target != null)
            {
                player = target.transform;
                navmeshAgent.SetDestination(player.transform.position);
            }
            else
            {
                RoamAround();
                setRandomPointTimer += Time.deltaTime;
            }
        }
    }

    IEnumerator skeletonArcherAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject shoot = Instantiate(archerArrow, transform.position + new Vector3(0, 1.4f, 0), transform.rotation) as GameObject;
        shoot.rigidbody.AddForce(transform.forward * 1000);
        shoot.rigidbody.useGravity = false;
    }

    void Update()
    {

        animator.SetFloat("Speed", direction.sqrMagnitude);
        navmeshAgent.enabled = (dead == false) ? true : false;

        if (player == null) SearchForTarget();
        else if (player != null && player.tag == "Player")
        {
            target = player.gameObject;
            navmeshAgent.SetDestination(player.transform.position);
            transform.LookAt(player);
            int randomIndex = Random.Range(0, 10);

            if (Vector3.Distance(player.transform.position, this.transform.position) < radius)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= rateOfAttack)
                {
                    animator.SetTrigger("Attack");
                    StartCoroutine(skeletonArcherAttack(0.95f));
                    attackTimer = 0;
                }
            }
        }

        if (navmeshAgent.velocity.magnitude == 0)
            animator.SetFloat("Speed", 0);
        else
            if (navmeshAgent.velocity.sqrMagnitude >= 1)
                animator.SetFloat("Speed", 1);
    }
}
