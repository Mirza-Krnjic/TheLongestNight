using UnityEngine;
using UnityEngine.AI; //this one u have to include

public class EnemyAI : MonoBehaviour
{
    [SerializeField] int damage = 9;
    [SerializeField] AudioSource myPlayer;
    [SerializeField] Animator hurtAnim;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 13f;
    [SerializeField] float attackRange = 4f;
    [SerializeField] float turnSpeed = 5f;
    public AudioSource enemyAudioSource;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth enemyHealth;
    CapsuleCollider zCollider;

    private Collider[] collidersToDisable;
    private int aryIndex = -1;
    private Animator enemyAnimator;


    [SerializeField] bool biting = false;

    void Awake()
    {
        enemyAnimator = GetComponent<Animator>();

        if (biting)
            enemyAnimator.SetTrigger("bite");

        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        zCollider = GetComponent<CapsuleCollider>();
        target = SaveScript.targetPlayer;
        enemyAudioSource = GetComponent<AudioSource>();
        enemyAudioSource.clip = SaveScript._zombieSounds[Random.Range(0, SaveScript.soundsAryZize)];

        enemyAudioSource.Play();
        enemyAudioSource.playOnAwake = true;

        collidersToDisable = new Collider[2];
    }

    private void Start()
    {
        hurtAnim = SaveScript.hurtAnim;
        myPlayer = SaveScript.hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead())
        {

            this.enabled = false;
            navMeshAgent.enabled = false;

            zCollider.enabled = false;

            enemyAudioSource.gameObject.SetActive(false);
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
        if (distanceToTarget <= attackRange)
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
        enemyAnimator.SetBool("attack", false);
        enemyAnimator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    void AttackTarget()
    {
        enemyAnimator.SetBool("attack", true);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }



    public void takeDamage()
    {
        hurtAnim.SetTrigger("Hurt");
        SaveScript.PlayerHealth -= damage;
        SaveScript.HealthChanged = true;
        myPlayer.Play();
    }

    public void populateColiderAry(BoxCollider col)
    {
        collidersToDisable[++aryIndex] = col;
    }

    public void SetChaseRange(int givenChaseRange)
    {
        chaseRange = givenChaseRange;
    }

}
