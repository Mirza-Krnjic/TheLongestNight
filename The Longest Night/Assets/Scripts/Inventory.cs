using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;

    //WEAPON INVENTORY
    private int numberOfWeapons; //can potentialy add to med, ammom, btry
    private GameObject[] weaponSlots;
    public GameObject weaponSlotHolder;

    //MEDKIT INVENTORY
    private GameObject[] medkitSlots;
    public GameObject medkitPanel;

    //BATTERY INVENTORY
    private GameObject[] batterySlots;
    public GameObject batteryPanel;

    //AMMOBOX INVENTORY
    private GameObject[] ammoBoxSlots;
    public GameObject ammoBoxPanel;

    //KEYs
    private GameObject[] keySlots;
    public GameObject keyPanel;

    [SerializeField] GameObject batteryForeground;
    float batteryFillAmount;

    //number of items
    int numberOfBatteries;
    int numberOfMedkits;
    int numberOfAmmoboxes;

    //audio
    private AudioSource audioPlayer;
    [SerializeField] AudioClip medkitPickupSound;
    [SerializeField] AudioClip BatteryPickupSound;

    bool inventoryPanelIsActive = false;
    bool optionsActive = false;

    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject weapons;
    [SerializeField] GameObject FPS_UI;
    [SerializeField] AudioListener playerAudioListener;

    void Start()
    {

        optionsMenu.gameObject.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
        Cursor.visible = false;
        inventoryPanelIsActive = false;
        InventoryPanel.gameObject.SetActive(false);
        batteryFillAmount = batteryForeground.gameObject.GetComponent<Image>().fillAmount;

        initWeapons();
        initMedkits();
        initBatteries();
        initAmmobox();
        initKeys();

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsActive == false)//menu on
            {
                FPS_UI.gameObject.SetActive(false);
                weapons.gameObject.SetActive(false);
                Time.timeScale = 0f;
                optionsMenu.gameObject.SetActive(true);
                optionsActive = true;
                Cursor.visible = true;

                playerAudioListener.enabled = false;
            }
            else if (optionsActive == true)//menu off
            {
                Time.timeScale = 1f;
                optionsMenu.gameObject.SetActive(false);
                optionsActive = false;
                Cursor.visible = false;
                weapons.gameObject.SetActive(true);
                FPS_UI.gameObject.SetActive(true);

                playerAudioListener.enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanelIsActive == false)
            {
                Time.timeScale = 0f;
                inventoryPanelIsActive = true;
                InventoryPanel.gameObject.SetActive(true);
                Cursor.visible = true;
            }
            else if (inventoryPanelIsActive == true)
            {
                Time.timeScale = 1f;
                inventoryPanelIsActive = false;
                InventoryPanel.gameObject.SetActive(false);
                Cursor.visible = false;
            }
        }

        CheckInventory();
    }

    void enableMedkits(int index)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < index)
                medkitSlots[i].gameObject.SetActive(true);
            else
                medkitSlots[i].gameObject.SetActive(false);
        }
    }
    void enableBatteries(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < index)
                batterySlots[i].gameObject.SetActive(true);
            else
                batterySlots[i].gameObject.SetActive(false);
        }
    }
    void enableAmmobox(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < index)
                ammoBoxSlots[i].gameObject.SetActive(true);
            else
                ammoBoxSlots[i].gameObject.SetActive(false);
        }
    }

    void CheckInventory()
    {
        numberOfBatteries = SaveScript.baterries;
        numberOfMedkits = SaveScript.Medkits;
        numberOfAmmoboxes = SaveScript.ammoBoxes;



        switch (numberOfMedkits)
        {
            case 1:
                {
                    enableMedkits(1);
                    break;
                }
            case 2:
                {
                    enableMedkits(2);
                    break;
                }
            case 3:
                {
                    enableMedkits(3);
                    break;
                }
            case 4:
                {
                    enableMedkits(4);
                    break;
                }
            default:
                {
                    enableMedkits(0);
                    break;
                }
        }
        switch (numberOfBatteries)
        {
            case 1:
                {
                    enableBatteries(1);
                    break;
                }
            case 2:
                {
                    enableBatteries(2);
                    break;
                }
            case 3:
                {
                    enableBatteries(3);
                    break;
                }
            case 4:
                {
                    enableBatteries(4);
                    break;
                }
            case 5:
                {
                    enableBatteries(5);
                    break;
                }
            default: //when no batteries in inventory
                {
                    enableBatteries(0);
                    break;
                }
        }
        switch (numberOfAmmoboxes)
        {
            case 1:
                {
                    enableAmmobox(1);
                    break;
                }
            case 2:
                {
                    enableAmmobox(2);
                    break;
                }
            case 3:
                {
                    enableAmmobox(3);
                    break;
                }
            case 4:
                {
                    enableAmmobox(4);
                    break;
                }
            case 5:
                {
                    enableAmmobox(5);
                    break;
                }
            default: //when no batteries in inventory
                {
                    enableAmmobox(0);
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
            SaveScript.PlayerHealth += 40;
            SaveScript.HealthChanged = true;
            SaveScript.Medkits -= 1;
        }
        if (SaveScript.PlayerHealth > 100) SaveScript.PlayerHealth = 100;
    }
    public void AmmoUpdate()
    {
        for (int i = 0; i < numberOfWeapons; i++)
        {
            Weapon weaponScript = weaponSlots[i].gameObject.GetComponent<Weapon>();
            AmmoType currAmmoType = weaponScript.getAmmoType();

            weaponScript.getAmmoSlot().MaxoutCurrentAmmo(currAmmoType);
        }
    }
    public void BatteryUpdate()
    {
        audioPlayer.clip = BatteryPickupSound;
        audioPlayer.Play();
        batteryForeground.gameObject.GetComponent<Image>().fillAmount = 1f;
        SaveScript.baterries -= 1;
        SaveScript.batteryPower = 1f;
    }

    //setting active weapon
    private void activateUsedWeapon(int choice)
    {
        choice--;
        for (int i = 0; i < numberOfWeapons; i++)
        {
            if (i == choice)
                weaponSlots[i].gameObject.SetActive(true);
            else
                weaponSlots[i].gameObject.SetActive(false);
        }
    }
    public void activatePistol()
    {
        activateUsedWeapon(1);
    }
    public void activateHeavyPistol()
    {
        activateUsedWeapon(2);
    }
    public void actiavteShotgun()
    {
        activateUsedWeapon(3);
    }
    public void activateSMG()
    {
        activateUsedWeapon(4);
    }
    public void activateAK()
    {
        activateUsedWeapon(5);
    }

    void initWeapons()
    {
        numberOfWeapons = 5;
        weaponSlots = new GameObject[numberOfWeapons];
        for (int i = 0; i < numberOfWeapons; i++)
        {
            weaponSlots[i] = weaponSlotHolder.transform.GetChild(i).gameObject;
        }
    }
    void initMedkits()
    {
        medkitSlots = new GameObject[4]; //created 4 game objects
        for (int i = 0; i < 4; i++)
        {
            medkitSlots[i] = medkitPanel.transform.GetChild(i + 1).gameObject;
            medkitSlots[i].gameObject.SetActive(false);
        }
    }
    void initBatteries()
    {
        batterySlots = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            batterySlots[i] = batteryPanel.transform.GetChild(i + 1).gameObject;
            batterySlots[i].gameObject.SetActive(false);
        }
    }
    void initAmmobox()
    {
        ammoBoxSlots = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            ammoBoxSlots[i] = ammoBoxPanel.transform.GetChild(i + 1).gameObject;
            ammoBoxSlots[i].gameObject.SetActive(false);
        }
    }
    void initKeys()
    {
        keySlots = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            keySlots[i] = keyPanel.transform.GetChild(i + 1).gameObject;

        }
        for (int i = 0; i < 4; i++)
            keySlots[i].gameObject.SetActive(false);

    }
    public void activateKey(int index) //1cabin, 2room, 3house, 4curch
    {
        index--;
        for (int i = 0; i < 4; i++)
        {
            if (i == index)
                keySlots[i].gameObject.SetActive(true);
        }
    }
}
