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
        // if (Physics.Raycast(ray, out hit, rayDistance))*/
        //hit.transform.tag = "Untagged";
        if (Physics.Raycast(ray.origin, ray.direction, out hit, rayDistance))
        {
            if (hit.transform.tag == "Medkit")
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
            }
            else if (hit.transform.tag == "Battery")
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
            }
            else
            {
                canSeePickup = false;
                Debug.Log("Raycast doesnt hit medkit");
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
