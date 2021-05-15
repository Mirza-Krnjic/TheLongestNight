using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanEnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent nav;
    private NavMeshHit hit;
    private bool blocked = false;
    private bool runToPlayer = false;
    private float distanceToPlayer;
    private bool isChecking = true;
    private int faileChecks = 0;

    [SerializeField] Transform player;
    [SerializeField] Animator anim;
    [SerializeField] GameObject enemy;
    [SerializeField] float maxRange = 35f;
    [SerializeField] int maxChecks = 3;
    [SerializeField] float walkSpeed = 1.6f;
    [SerializeField] float chaseSpeed = 8.5f;
    [SerializeField] float attackDistance = 2.5f;
    [SerializeField] float attackRoteteSpeed = 2.0f;
    [SerializeField] float checkTime = 3f; //close time between checks
    [SerializeField] EnemyHealth enemyHealth;
    //[SerializeField] GameObject chaseMusic;



    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        //chaseMusic.gameObject.SetActive(false);
        //enemyHealth = GetComponentInChildren<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            nav.enabled = false;
            this.enabled = false;
            
            
            //zCollider.enabled = false;
        }

        distanceToPlayer = Vector3.Distance(player.position, enemy.transform.position);
        if (distanceToPlayer < maxRange)
        {
            if (isChecking)
            {
                isChecking = false;

                blocked = NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);

                if (blocked == false)
                {
                    Debug.Log("I can see the plyser!");
                    runToPlayer = true;
                    faileChecks = 0;
                }
                if (blocked == true)
                {
                    Debug.Log("Cant see the player!");
                    runToPlayer = false;
                    anim.SetInteger("State", 1);
                    faileChecks++;
                }

                StartCoroutine(TimedCheck());
            }
        }

        if (runToPlayer)
        {
            //chaseMusic.gameObject.SetActive(true);
            enemy.GetComponent<HumanEnemyMove>().enabled = false;
            if (distanceToPlayer > attackDistance)
            {
                nav.isStopped = false;
                anim.SetInteger("State", 2);
                nav.acceleration = 24;
                nav.SetDestination(player.position);
                nav.speed = chaseSpeed;
            }
            if (distanceToPlayer < attackDistance - 0.5)
            {
                nav.isStopped = true;
                anim.SetInteger("State", 3); //attacking !!!!!!!!!
                nav.acceleration = 180;

                //enemy rotation problem
                Vector3 pos = (player.position - enemy.transform.position).normalized;
                Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, posRotation, Time.deltaTime * attackRoteteSpeed);


            }
        }
        else if (runToPlayer == false)
        {
            nav.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            runToPlayer = true;
        }
    }
    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(checkTime);
        isChecking = true;

        if (faileChecks > maxChecks)
        {
            //chaseMusic.gameObject.SetActive(false);
            enemy.GetComponent<HumanEnemyMove>().enabled = true;
            nav.isStopped = false;
            nav.speed = walkSpeed;
            faileChecks = 0;
        }
    }
}
