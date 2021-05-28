using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HweaponDamage : MonoBehaviour
{
    [SerializeField] int HenemyWeaponDamage = 1;
    [SerializeField] Animator hurtAnim;
    private bool hitActive = false;
    [SerializeField] AudioSource myPlayer;
    public static BoxCollider boxColliderToDisable;
    private EnemyAI EnemyAIref;

    private void Start()
    {
        hurtAnim = SaveScript.hurtAnim;
        myPlayer = SaveScript.hitSound;
        boxColliderToDisable = GetComponent<BoxCollider>();
        EnemyAIref = GetComponentInParent<EnemyAI>();
        EnemyAIref.populateColiderAry(boxColliderToDisable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                hurtAnim.SetTrigger("Hurt");
                SaveScript.PlayerHealth -= HenemyWeaponDamage;
                SaveScript.HealthChanged = true;
                myPlayer.Play();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }
}
