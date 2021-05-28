using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] GameObject pickupMessage;
    [SerializeField] AudioClip medkitPickupSound;
    [SerializeField] AudioClip batteryPickupSound;
    [SerializeField] AudioSource audioPlayer;
    private bool inRange = false;
    private bool pickedUp = false;
    private GameObject refToGameObject;

    public Inventory inventoryScript;


    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (inRange == true && pickedUp == false)
        {
            pickUpItem();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pickedUp = false;
        string tag = other.gameObject.transform.tag;
        switch (tag)
        {
            case "Medkit":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            case "Battery":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            case "AmmoBox":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            case "CabinKey":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            case "HouseKey":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            case "RoomKey":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    break;
                }
            case "ChurchKey":
                {
                    refToGameObject = other.gameObject;
                    pickupMessage.gameObject.SetActive(true);
                    inRange = true;
                    return;
                }
            default:
                {
                    inRange = false;
                    pickupMessage.gameObject.SetActive(false);
                    return;
                }
        }
    }

    void pickUpItem()
    {
        string tag = refToGameObject.gameObject.transform.tag;
        switch (tag)
        {
            case "Medkit":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (SaveScript.Medkits < 4)
                        {
                            Destroy(refToGameObject);
                            SaveScript.Medkits += 1;
                            audioPlayer.clip = medkitPickupSound;
                            audioPlayer.Play();
                            pickedUp = true;
                            pickupMessage.gameObject.SetActive(false);
                        }

                    }
                    break;
                }
            case "Battery":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (SaveScript.baterries < 5)
                        {
                            Destroy(refToGameObject.transform.gameObject);
                            SaveScript.baterries += 1;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                            pickedUp = true;
                             pickupMessage.gameObject.SetActive(false);
                        }
                    }
                    break;
                }
            case "AmmoBox":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (SaveScript.ammoBoxes < 5)
                        {
                            Destroy(refToGameObject.transform.gameObject);
                            SaveScript.ammoBoxes += 1;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                            pickedUp = true;
                             pickupMessage.gameObject.SetActive(false);
                        }
                    }
                    break;
                }
            case "CabinKey":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryScript.activateKey(1);
                        Destroy(refToGameObject.transform.gameObject);
                        SaveScript.CabinKey = true;
                        audioPlayer.clip = batteryPickupSound;
                        audioPlayer.Play();
                        pickedUp = true;
                    }
                    break;
                }
            case "HouseKey":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryScript.activateKey(3);
                        Destroy(refToGameObject.transform.gameObject);
                        SaveScript.HouseKey = true;
                        audioPlayer.clip = batteryPickupSound;
                        audioPlayer.Play();
                        pickedUp = true;
                    }
                    break;
                }
            case "RoomKey":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryScript.activateKey(2);
                        Destroy(refToGameObject.transform.gameObject);
                        SaveScript.RoomKey = true;
                        audioPlayer.clip = batteryPickupSound;
                        audioPlayer.Play();
                        pickedUp = true;
                    }
                    break;
                }
            case "ChurchKey":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        inventoryScript.activateKey(4);
                        Destroy(refToGameObject.transform.gameObject);
                        SaveScript.CurchKey = true;
                        audioPlayer.clip = batteryPickupSound;
                        audioPlayer.Play();
                        pickedUp = true;
                    }
                    break;
                }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickupMessage.gameObject.SetActive(false);
        inRange = false;
    }
}
