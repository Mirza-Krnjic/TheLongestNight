using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpactEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    public Text ammoText;
    private int ammoCount; 
    private int ammoMaxCount = 10;
    

    private void Start()
    {
        ammoCount = ammoMaxCount;
        ammoText.text = ammoCount.ToString();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            Shoot();
            AmmoSystem();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            CreateImpactExploation(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; //if you hit smtn other than d enemy
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void CreateImpactExploation(RaycastHit hit)
    {
        GameObject impactEffect = Instantiate(hitImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, .1f);
    }

    private void AmmoSystem()
    {
        ammoCount--;
            ammoText.text = ammoCount.ToString();
       
        if(ammoCount == 0)
        {
            ammoText.text = "R to reload";
        }


    }

    private void Reload()
    {
        StartCoroutine(ReloadCorutine(2));

    }
    IEnumerator ReloadCorutine(float time)
    {
        yield return new WaitForSeconds(time);
 
        ammoCount = ammoMaxCount;
        ammoText.text = ammoCount.ToString();
    }

}
