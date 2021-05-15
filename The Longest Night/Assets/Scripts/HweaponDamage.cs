using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HweaponDamage : MonoBehaviour
{
    [SerializeField] int HenemyWeaponDamage = 1;
    [SerializeField] Animator hurtAnim;
    private bool hitActive = false;
    [SerializeField] AudioSource myPlayer;


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
