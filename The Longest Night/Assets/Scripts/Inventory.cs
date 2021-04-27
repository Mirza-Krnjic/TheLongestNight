using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;

    //Medkits
    [SerializeField] GameObject medkitImage1;
    [SerializeField] GameObject medkitButton1;
    [SerializeField] GameObject medkitImage2;
    [SerializeField] GameObject medkitButton2;
    [SerializeField] GameObject medkitImage3;
    [SerializeField] GameObject medkitButton3;
    [SerializeField] GameObject medkitImage4;
    [SerializeField] GameObject medkitButton4;

    //Batteries
    [SerializeField] GameObject batteryImage1;
    [SerializeField] GameObject batteryButton1;
    [SerializeField] GameObject batteryImage2;
    [SerializeField] GameObject batteryButton2;
    [SerializeField] GameObject batteryImage3;
    [SerializeField] GameObject batteryButton3;
    [SerializeField] GameObject batteryImage4;
    [SerializeField] GameObject batteryButton4;
    [SerializeField] GameObject batteryImage5;
    [SerializeField] GameObject batteryButton5;


    [SerializeField] GameObject batteryForeground;
    float batteryFillAmount;
    int numberOfBatteries;
    int numberOfMedkits;
    private AudioSource audioPlayer;
    [SerializeField] AudioClip medkitPickupSound;
    [SerializeField] AudioClip BatteryPickupSound;

    bool inventoryPanelIsActive = false;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        Cursor.visible = false;
        inventoryPanelIsActive = false;
        InventoryPanel.gameObject.SetActive(false);

        medkitImage1.gameObject.SetActive(false);
        medkitButton1.gameObject.SetActive(false);
        medkitImage2.gameObject.SetActive(false);
        medkitButton2.gameObject.SetActive(false);
        medkitImage3.gameObject.SetActive(false);
        medkitButton3.gameObject.SetActive(false);
        medkitImage4.gameObject.SetActive(false);
        medkitButton4.gameObject.SetActive(false);

        batteryImage1.gameObject.SetActive(false);
        batteryButton1.gameObject.SetActive(false);
        batteryImage2.gameObject.SetActive(false);
        batteryButton2.gameObject.SetActive(false);
        batteryImage3.gameObject.SetActive(false);
        batteryButton3.gameObject.SetActive(false);
        batteryImage4.gameObject.SetActive(false);
        batteryButton4.gameObject.SetActive(false);
        batteryImage5.gameObject.SetActive(false);
        batteryButton5.gameObject.SetActive(false);

        batteryFillAmount = batteryForeground.gameObject.GetComponent<Image>().fillAmount;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanelIsActive == false)
            {
                inventoryPanelIsActive = true;
                InventoryPanel.gameObject.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (inventoryPanelIsActive == true)
            {
                inventoryPanelIsActive = false;
                InventoryPanel.gameObject.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }

        CheckInventory();
    }

    void CheckInventory() //displays certian items in certian position i avaible
    {
        numberOfBatteries = SaveScript.baterries;
        numberOfMedkits = SaveScript.Medkits;

        switch (numberOfMedkits)
        {
            case 1:
                {
                    medkitImage1.gameObject.SetActive(true);
                    medkitButton1.gameObject.SetActive(true);
                    medkitImage2.gameObject.SetActive(false);
                    medkitButton2.gameObject.SetActive(false);
                    medkitImage3.gameObject.SetActive(false);
                    medkitButton3.gameObject.SetActive(false);
                    medkitImage4.gameObject.SetActive(false);
                    medkitButton4.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    medkitImage1.gameObject.SetActive(true);
                    medkitButton1.gameObject.SetActive(false);
                    medkitImage2.gameObject.SetActive(true);
                    medkitButton2.gameObject.SetActive(true);
                    medkitImage3.gameObject.SetActive(false);
                    medkitButton3.gameObject.SetActive(false);
                    medkitImage4.gameObject.SetActive(false);
                    medkitButton4.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    medkitImage1.gameObject.SetActive(true);
                    medkitButton1.gameObject.SetActive(false);
                    medkitImage2.gameObject.SetActive(true);
                    medkitButton2.gameObject.SetActive(false);
                    medkitImage3.gameObject.SetActive(true);
                    medkitButton3.gameObject.SetActive(true);
                    medkitImage4.gameObject.SetActive(false);
                    medkitButton4.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    medkitImage1.gameObject.SetActive(true);
                    medkitButton1.gameObject.SetActive(false);
                    medkitImage2.gameObject.SetActive(true);
                    medkitButton2.gameObject.SetActive(false);
                    medkitImage3.gameObject.SetActive(true);
                    medkitButton3.gameObject.SetActive(false);
                    medkitImage4.gameObject.SetActive(true);
                    medkitButton4.gameObject.SetActive(true);
                    break;
                }
            default:
                {
                    medkitImage1.gameObject.SetActive(false);
                    medkitButton1.gameObject.SetActive(false);
                    medkitImage2.gameObject.SetActive(false);
                    medkitButton2.gameObject.SetActive(false);
                    medkitImage3.gameObject.SetActive(false);
                    medkitButton3.gameObject.SetActive(false);
                    medkitImage4.gameObject.SetActive(false);
                    medkitButton4.gameObject.SetActive(false);
                    break;
                }
        }

        switch (numberOfBatteries)
        {
            case 1:
                {
                    batteryImage1.gameObject.SetActive(true);
                    batteryButton1.gameObject.SetActive(true);
                    batteryImage2.gameObject.SetActive(false);
                    batteryButton2.gameObject.SetActive(false);
                    batteryImage3.gameObject.SetActive(false);
                    batteryButton3.gameObject.SetActive(false);
                    batteryImage4.gameObject.SetActive(false);
                    batteryButton4.gameObject.SetActive(false);
                    batteryImage5.gameObject.SetActive(false);
                    batteryButton5.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    batteryImage1.gameObject.SetActive(true);
                    batteryButton1.gameObject.SetActive(false);
                    batteryImage2.gameObject.SetActive(true);
                    batteryButton2.gameObject.SetActive(true);
                    batteryImage3.gameObject.SetActive(false);
                    batteryButton3.gameObject.SetActive(false);
                    batteryImage4.gameObject.SetActive(false);
                    batteryButton4.gameObject.SetActive(false);
                    batteryImage5.gameObject.SetActive(false);
                    batteryButton5.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    batteryImage1.gameObject.SetActive(true);
                    batteryButton1.gameObject.SetActive(false);
                    batteryImage2.gameObject.SetActive(true);
                    batteryButton2.gameObject.SetActive(false);
                    batteryImage3.gameObject.SetActive(true);
                    batteryButton3.gameObject.SetActive(true);
                    batteryImage4.gameObject.SetActive(false);
                    batteryButton4.gameObject.SetActive(false);
                    batteryImage5.gameObject.SetActive(false);
                    batteryButton5.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    batteryImage1.gameObject.SetActive(true);
                    batteryButton1.gameObject.SetActive(false);
                    batteryImage2.gameObject.SetActive(true);
                    batteryButton2.gameObject.SetActive(false);
                    batteryImage3.gameObject.SetActive(true);
                    batteryButton3.gameObject.SetActive(false);
                    batteryImage4.gameObject.SetActive(true);
                    batteryButton4.gameObject.SetActive(true);
                    batteryImage5.gameObject.SetActive(false);
                    batteryButton5.gameObject.SetActive(false);
                    break;
                }
            case 5:
                {
                    batteryImage1.gameObject.SetActive(true);
                    batteryButton1.gameObject.SetActive(false);
                    batteryImage2.gameObject.SetActive(true);
                    batteryButton2.gameObject.SetActive(false);
                    batteryImage3.gameObject.SetActive(true);
                    batteryButton3.gameObject.SetActive(false);
                    batteryImage4.gameObject.SetActive(true);
                    batteryButton4.gameObject.SetActive(false);
                    batteryImage5.gameObject.SetActive(true);
                    batteryButton5.gameObject.SetActive(true);
                    break;
                }
            default: //when no batteries in inventory
                {
                    batteryImage1.gameObject.SetActive(false);
                    batteryButton1.gameObject.SetActive(false);
                    batteryImage2.gameObject.SetActive(false);
                    batteryButton2.gameObject.SetActive(false);
                    batteryImage3.gameObject.SetActive(false);
                    batteryButton3.gameObject.SetActive(false);
                    batteryImage4.gameObject.SetActive(false);
                    batteryButton4.gameObject.SetActive(false);
                    batteryImage5.gameObject.SetActive(false);
                    batteryButton5.gameObject.SetActive(false);
                    break;
                }
        }
    }

    public void HealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100)
        {
            audioPlayer.clip = medkitPickupSound;
            audioPlayer.Play();
            SaveScript.PlayerHealth += 10;
            SaveScript.HealthChanged = true;
            SaveScript.Medkits -= 1;
        }
        if (SaveScript.PlayerHealth > 100) SaveScript.PlayerHealth = 100;
    }
    public void BatteryUpdate()
    {
        audioPlayer.clip = BatteryPickupSound;
        audioPlayer.Play();
        batteryForeground.gameObject.GetComponent<Image>().fillAmount = 1f;
        SaveScript.baterries -= 1;
        SaveScript.batteryPower = 1f;
    }
}
