using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] AmmoType ammoType;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpactEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float fireRate = 0.5f;
    bool readyToShoot = true;


    public Text ammoText;
    private int ammoCount;

    private void OnEnable()
    {
        readyToShoot = true;
    }

    private void DisplayAmmo()
    {
        ammoCount = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = ammoCount.ToString();
    }

    void Update()
    {
        DisplayAmmo();
        
        if (Input.GetButtonDown("Fire1") && readyToShoot == true)
        {
            StartCoroutine(Shoot());

            AmmoSystem();
        }

        if (Input.GetKey(KeyCode.R) && ammoSlot.GetCurrentAmmo(ammoType) == 0)
        {
            Reload();
        }

    }

    IEnumerator Shoot()
    {
        readyToShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(fireRate);
        readyToShoot = true;
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
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();

        if (ammoSlot.GetCurrentAmmo(ammoType) == 0)
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

        ammoSlot.ReloadCurrentAmmo(ammoType);
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

}
