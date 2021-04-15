using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpactEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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
        Destroy(impactEffect,1);
    }
}
