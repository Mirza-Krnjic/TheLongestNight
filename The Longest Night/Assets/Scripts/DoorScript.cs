using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    private Animator anim;

    public bool locked;
    private string doorType;

    //UI
    public bool isOpen = false;
    private bool inRange = false;
    [SerializeField] Text doorOpenText;
    [SerializeField] Text doorCloseText;
    [SerializeField] Text needDoorKeyText;

    //sound related vars
    private AudioSource myPlayer;
    [SerializeField] AudioClip CabinDoorSound;
    [SerializeField] AudioClip RoomDoorSound;
    [SerializeField] AudioClip HouseDoorSound;
    //door types
    [SerializeField] bool cabin;
    [SerializeField] bool room;
    [SerializeField] bool house;
    [SerializeField] bool church;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        setDoorText();
        myPlayer = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        HasKey4Door();

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (!locked)
            {
                DoorOpen();
                PlayDoorSound();
            }
        }

    }

    void HasKey4Door()
    {
        if (room == true && SaveScript.RoomKey == true)
            locked = false;
        if (cabin == true && SaveScript.CabinKey == true)
            locked = false;
        if (house == true && SaveScript.HouseKey == true)
            locked = false;
        if (church == true && SaveScript.CurchKey == true)
            locked = false;
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (locked == false)
            {
                if (isOpen == false)
                {
                    anim.SetTrigger("Open");
                    isOpen = true;
                }
            }
        }

        if (locked)
        {
            needDoorKeyText.text = "You need the " + doorType + " key.";
            needDoorKeyText.gameObject.SetActive(true);
        }
        else if (isOpen)
        {
            doorOpenText.gameObject.SetActive(false);
            doorCloseText.gameObject.SetActive(true);
            needDoorKeyText.gameObject.SetActive(false);
        }
        else
        {
            doorOpenText.gameObject.SetActive(true);
            doorCloseText.gameObject.SetActive(false);
            needDoorKeyText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        doorOpenText.gameObject.SetActive(false);
        doorCloseText.gameObject.SetActive(false);
        needDoorKeyText.gameObject.SetActive(false);

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
    void setDoorText()
    {
        doorOpenText.gameObject.SetActive(false);
        doorCloseText.gameObject.SetActive(false);
        needDoorKeyText.gameObject.SetActive(false);

        if (cabin == true)
            doorType = "cabin";
        else if (room == true)
            doorType = "room";
        else if (house == true)
            doorType = "house";
        else if (church == true)
            doorType = "church";
    }
}
