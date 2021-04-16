using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints= 100f;
    public Slider slider;
     float maxHealth = 100f;
     private float currHealth;

     public void Start()
     {
         currHealth = maxHealth;
         slider.value = currHealth;
     }

     public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        ReduceHealth(damage);
        if(hitPoints <=0)
        {
            GetComponent<PlayerDeathHandeler>().HandleDeath();
        }
    }

     public void ReduceHealth(float damage)
     {
         currHealth -= damage;
         slider.value = currHealth;
     }
     
}
