using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    private Animator anim;

    public bool locked;
    public string doorType;

    //UI
    public bool isOpen = false;
    private bool inRange = false;
    [SerializeField] Text doorOpenText;
    [SerializeField] Text doorCloseText;

    //sound related vars
    private AudioSource myPlayer;
    [SerializeField] AudioClip CabinDoorSound;
    [SerializeField] AudioClip RoomDoorSound;
    [SerializeField] AudioClip HouseDoorSound;
    [SerializeField] bool cabin;
    [SerializeField] bool room;
    [SerializeField] bool house;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorOpenText.gameObject.SetActive(false);
        doorCloseText.gameObject.SetActive(false);
        myPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            DoorOpen();
            PlayDoorSound();
        }


    }

    public void DoorOpen()
    {
        if (isOpen == false)
        {
            anim.SetTrigger("Open");
            isOpen = true;

        }
        else if (isOpen == true)
        {
            anim.SetTrigger("Close");
            isOpen = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inRange = true;
        if (isOpen)
        {
            doorOpenText.gameObject.SetActive(false);
            doorCloseText.gameObject.SetActive(true);
        }
        else
        {
            doorOpenText.gameObject.SetActive(true);
            doorCloseText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        doorOpenText.gameObject.SetActive(false);
        doorCloseText.gameObject.SetActive(false);

        inRange = false;
    }

    void PlayDoorSound()
    {
        if (cabin == true)
        {
            myPlayer.clip = CabinDoorSound;
            myPlayer.Play();
        }
        else if (house == true)
        {
            myPlayer.clip = HouseDoorSound;
            myPlayer.Play();
        }
        else if (room == true)
        {
            myPlayer.clip = RoomDoorSound;
            myPlayer.Play();
        }
    }
}
