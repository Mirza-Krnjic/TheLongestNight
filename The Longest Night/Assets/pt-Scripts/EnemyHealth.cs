using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    EnemyAI enemyAIref;

    public bool IsDead()
    {
        return isDead;
    }

    private void Start()
    {
        enemyAIref = GetComponentInParent<EnemyAI>();

    }

    public void TakeDamage(float damage)
    {
        this.GetComponentInParent<EnemyAI>().HasRecivedDamage();
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            EnemyDeath();
        }
    }
    void EnemyDeath()
    {
        if (isDead) return;
        isDead = true;


        enemyAIref.disableColiders();
        enemyAIref.enabled = false;
       

        GetComponentInParent<NavMeshAgent>().enabled = false;
        GetComponentInParent<CapsuleCollider>().enabled = false;


        
        GetComponentInParent<Animator>().SetTrigger("die");
        
        SaveScript.enemiesOnScreen--;
        //SaveScript.enemiesCurrent++; later will trigget final scene (final boss)
    }
}
