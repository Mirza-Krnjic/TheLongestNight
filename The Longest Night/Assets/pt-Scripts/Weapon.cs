using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    //Gun stats
    [SerializeField] float damage = 30f;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;

    //BOOLs
    bool shooting, reloading;
    bool isAimed;
    public bool readyToShoot = true;

    //Reference
    [SerializeField] Camera playerCamera;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpactEffect;


    //sound, UI
    Animator anim;
    public Text ammoText;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioSource reloadSound;
    //[SerializeField] Canvas canvasToDisabe;


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        anim = GetComponent<Animator>();
        anim.SetBool("reloading", false);
        isAimed = false;
        reloading = false;
    }

    private void DisplayAmmo()
    {
        //text.SetText(bulletsLeft + " / " + magazineSize);
        // ammoText.text = bulletsLeft.ToString();
        ammoText.text = (bulletsLeft.ToString() + "/" + ammoSlot.GetCurrentAmmo(ammoType));

        if (bulletsLeft == 0)
        {
            ammoText.text = "R to reload";
        }
    }

    void Update()
    {
        if (!inventoryPanel.gameObject.activeSelf) //if inventory is not acttive
            MyInput();

        DisplayAmmo();

        WeaponAnimHandler();
    }

    void WeaponAnimHandler()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("running", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
            anim.SetBool("running", false);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) //if player is moving
            anim.SetBool("walking", true);
        else if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;

            PlayMuzzleFlash();
            shootSound.Play();
            anim.SetTrigger("ShootTrigger");

            Shoot();
        }

        //Handels aiming
        if (Input.GetMouseButtonDown(1))
        {
            if (isAimed == false)
            {
                isAimed = true;
                anim.SetBool("AIM", true);
                //GetComponentInParent<FirstPersonAIO>().playerCanMove = false;
                //canvasToDisabe.enabled = false;
            }
            else
            {
                isAimed = false;
                anim.SetBool("AIM", false);
                //GetComponentInParent<FirstPersonAIO>().playerCanMove = true;
                // canvasToDisabe.enabled = true;
            }
        }
    }
    private void Shoot()
    {

        readyToShoot = false;


        //Spread
        float x = UnityEngine.Random.Range(-spread, spread);
        float y = UnityEngine.Random.Range(-spread, spread);

        if (isAimed)
        {
            x = 0f;
            y = 0f;
        }


        //Calculate Direction with Spread
        Vector3 direction = playerCamera.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(playerCamera.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);
            CreateImpactExploation(rayHit);
            if (rayHit.collider.CompareTag("Enemy"))
            {
                EnemyHealth target = rayHit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(damage);
            }
        }
        else if (Physics.Raycast(playerCamera.transform.position, direction, out rayHit, range))
            CreateImpactExploation(rayHit);

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));

        bulletsLeft--;
        bulletsShot--; //bulletspertap

        Invoke("ResetShot", timeBetweenShooting);

        //if (bulletsShot > 0 && bulletsLeft > 0)
        //   Invoke("Shoot", timeBetweenShots);

        if (bulletsShot > 0)
        {
            Invoke("Shoot", timeBetweenShots);
            bulletsLeft++;
        }

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void CreateImpactExploation(RaycastHit hit)
    {
        GameObject impactEffect = Instantiate(hitImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, .1f);
    }



    private void Reload()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) == 0f) return;

        reloadSound.Play();

        reloading = true;

        anim.SetTrigger("ReloadTrigger");

        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        int remainingAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        if (ammoSlot.GetCurrentAmmo(ammoType) == 0f) return;

        else if (bulletsLeft > 0)
        {
            ammoSlot.IncraseCurrentAmmo(ammoType, bulletsLeft); //incrase total ammo from clip
            bulletsLeft = 0; // null the clip
            if (ammoSlot.GetCurrentAmmo(ammoType) >= magazineSize) // if can fit MAG
            {
                ammoSlot.ReduceCurrentAmmo(ammoType, magazineSize);
                bulletsLeft = magazineSize;
            }
            else
            {
                bulletsLeft = ammoSlot.GetCurrentAmmo(ammoType);
                ammoSlot.ReduceCurrentAmmo(ammoType, remainingAmmo);
            }
        }
        else if (bulletsLeft == 0)
        {
            if (ammoSlot.GetCurrentAmmo(ammoType) >= magazineSize) // if can fit MAG
            {
                ammoSlot.ReduceCurrentAmmo(ammoType, magazineSize);
                bulletsLeft = magazineSize;
            }
            else
            {
                bulletsLeft = ammoSlot.GetCurrentAmmo(ammoType);
                ammoSlot.ReduceCurrentAmmo(ammoType, remainingAmmo);
            }
        }

        reloading = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    public AmmoType getAmmoType()
    {
        return ammoType;
    }
    public Ammo getAmmoSlot()
    {
        return ammoSlot;
    }
}
