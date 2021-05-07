using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float distance = 4f;
    [SerializeField] GameObject pickupMessage;
    [SerializeField] AudioClip medkitPickupSound;
    [SerializeField] AudioClip batteryPickupSound;
    private AudioSource audioPlayer;

    private float rayDistance;
    private bool canSeePickup = false;
    public Inventory inventoryScript;

    //sdasdasdasdasda

    void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        rayDistance = distance;
        audioPlayer = GetComponent<AudioSource>();
    }


    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        ray.origin = ray.GetPoint(rayDistance);
        ray.direction = -ray.direction;
        int layer_mask = LayerMask.GetMask("PickupLayer");

        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayDistance))
        {
            switch (hit.transform.tag)
            {
                case "Medkit":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (SaveScript.Medkits < 4)
                            {
                                Destroy(hit.transform.gameObject);
                                SaveScript.Medkits += 1;
                                audioPlayer.clip = medkitPickupSound;
                                audioPlayer.Play();
                            }
                        }
                        break;
                    }
                case "Battery":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (SaveScript.baterries < 5)
                            {
                                Destroy(hit.transform.gameObject);
                                SaveScript.baterries += 1;
                                audioPlayer.clip = batteryPickupSound;
                                audioPlayer.Play();
                            }
                        }
                        break;
                    }
                case "AmmoBox":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (SaveScript.ammoBoxes < 5)
                            {
                                Destroy(hit.transform.gameObject);
                                SaveScript.ammoBoxes += 1;
                                audioPlayer.clip = batteryPickupSound;
                                audioPlayer.Play();
                            }
                        }
                        break;
                    }
                case "CabinKey":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            inventoryScript.activateKey(1);
                            Destroy(hit.transform.gameObject);
                            SaveScript.CabinKey = true;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                        }
                        break;
                    }
                case "HouseKey":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            inventoryScript.activateKey(3);
                            Destroy(hit.transform.gameObject);
                            SaveScript.HouseKey = true;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                        }
                        break;
                    }
                case "RoomKey":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            inventoryScript.activateKey(2);
                            Destroy(hit.transform.gameObject);
                            SaveScript.RoomKey = true;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                        }
                        break;
                    }
                case "ChurchKey":
                    {
                        canSeePickup = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            inventoryScript.activateKey(4);
                            Destroy(hit.transform.gameObject);
                            SaveScript.CurchKey = true;
                            audioPlayer.clip = batteryPickupSound;
                            audioPlayer.Play();
                        }
                        break;
                    }
                default:
                    {
                        canSeePickup = false;
                        break;
                    }
            }
        }

        if (canSeePickup == true)
        {
            pickupMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeePickup == false)
        {
            pickupMessage.gameObject.SetActive(false);
            rayDistance = distance;
        }
    }
}
