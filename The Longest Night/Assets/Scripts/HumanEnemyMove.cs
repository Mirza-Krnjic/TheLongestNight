using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanEnemyMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform theTarget;
    private float distanceToTarget;
    private int targetNumber = 1; //going to target 1

    private Animator anim;
    [SerializeField] float timeToLookAround = 3f;

    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    [SerializeField] Transform target4;
    [SerializeField] Transform target5;


    [SerializeField] float stopDistance = 2.0f;
    private bool hasStopped = false;
    private bool randomizer = true;
    private int nextTargetNumber;
    int maxTargets = 5;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        theTarget = target1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(theTarget.position, transform.position);
        if (distanceToTarget > stopDistance)
        {
            anim.SetInteger("State", 0);
            nav.SetDestination(theTarget.position);
            nav.isStopped = false;

            nextTargetNumber = targetNumber;
        }
        if (distanceToTarget < stopDistance)
        {
            nav.isStopped = true;
            anim.SetInteger("State", 1);
            StartCoroutine(LookAround());
            //targetNumber++;
            //if (targetNumber > maxTargets)
            //    targetNumber = 1;
            setTarget();
        }
    }
    void setTarget()
    {
        if (targetNumber == 1)
            theTarget = target1;
        if (targetNumber == 2)
            theTarget = target2;
        if (targetNumber == 3)
            theTarget = target3;
        if (targetNumber == 4)
            theTarget = target4;
        if (targetNumber == 5)
            theTarget = target5;
    }
    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(timeToLookAround);
        if (hasStopped == false)
        {
            hasStopped = true;

            if (randomizer)//occurs in one frame
            {
                randomizer = false;
                targetNumber = Random.Range(1, maxTargets);

                if (targetNumber == nextTargetNumber)
                {
                    targetNumber++;
                    if (targetNumber >= maxTargets)
                        targetNumber = 1;
                }
            }
            setTarget();

            yield return new WaitForSeconds(timeToLookAround);
            hasStopped = false;
            randomizer = true;
        }
    }
}
