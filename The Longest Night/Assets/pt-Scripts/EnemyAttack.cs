using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 1f;

    void Start()
    {
        target=FindObjectOfType<PlayerHealth>();
    }


    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        Debug.Log("Player is taking damage");
    }
}
