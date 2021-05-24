using UnityEngine;
using UnityEngine.AI; //this one u have to include

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth enemyHealth;
    CapsuleCollider zCollider;

    private Collider[] collidersToDisable;
    private int aryIndex = -1;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        zCollider = GetComponent<CapsuleCollider>();
        target = SaveScript.targetPlayer;

        collidersToDisable = new Collider[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            
            this.enabled = false;
            navMeshAgent.enabled = false;

            zCollider.enabled = false;


        }
        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position); //calcs the distance between enemy & target

            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;
            }
        }
    }
    public void HasRecivedDamage()//can be used later
    {
        isProvoked = true;
    }
    void EngageTarget() // chase and attack
    {
        TurnTowardsTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }
    void TurnTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void disableColiders()
    {
        foreach (var item in collidersToDisable)
        {
            item.enabled = false;
        }
    }

    public void populateColiderAry(BoxCollider col)
    {
        collidersToDisable[++aryIndex] = col;
    }

}
