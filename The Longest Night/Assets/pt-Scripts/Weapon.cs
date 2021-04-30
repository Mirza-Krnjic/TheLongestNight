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
    Animator anim;
    bool isAimed;
    [SerializeField] Canvas canvasToDisabe;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioSource reloadSound;


    public Text ammoText;
    private int ammoCount;

    private void OnEnable()
    {
        readyToShoot = true;
        anim = GetComponent<Animator>();
        anim.SetBool("reloading", false);
        isAimed = false;
    }

    private void DisplayAmmo()
    {
        ammoCount = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = ammoCount.ToString();
    }

    void Update()
    {
        DisplayAmmo();
        AmmoSystem();
        if (Input.GetButtonDown("Fire1") && readyToShoot == true)
        {
            StartCoroutine(Shoot());


        }

        if (Input.GetKey(KeyCode.R) && ammoSlot.GetCurrentAmmo(ammoType) == 0)
        {
            if ((anim.GetBool("running") == false && anim.GetBool("walking") == true) || anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                anim.SetBool("reloading", false);
                anim.SetTrigger("ReloadTrigger");

                Reload();

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (isAimed == false)
            {
                isAimed = true;
                anim.SetBool("AIM", true);
                canvasToDisabe.enabled = false;
            }
            else
            {
                isAimed = false;
                anim.SetBool("AIM", false);
                canvasToDisabe.enabled = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("running", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            anim.SetBool("running", false);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) //if player is moving
            anim.SetBool("walking", true);
        else if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);

    }

    IEnumerator Shoot()
    {
        readyToShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            shootSound.Play();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            //anim.SetBool("FIRE", true);
            anim.SetTrigger("ShootTrigger");
        }
        yield return new WaitForSeconds(fireRate);
        readyToShoot = true;
        anim.SetBool("FIRE", false);
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
        reloadSound.Play();
        StartCoroutine(ReloadCorutine(3.2f));


    }
    IEnumerator ReloadCorutine(float time)
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("reloading", true);
        ammoSlot.ReloadCurrentAmmo(ammoType);
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

}
