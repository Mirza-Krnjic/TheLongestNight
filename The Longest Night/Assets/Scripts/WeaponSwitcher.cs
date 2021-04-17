using System;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        processKeyInput();
        processScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetActiveWeapon();
        }
    }

    private void processScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    private void processKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentWeapon = 2;
    }

    void SetActiveWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
