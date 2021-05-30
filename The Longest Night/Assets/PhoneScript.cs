using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] GameObject phoneText;
    [SerializeField] GameObject pressText;
    [SerializeField] GameObject inventoryToDisable;
    private bool displayText = false;
    private bool inRange = false;
    private bool phoneCanvasIsEnabled = false;
    // Start is called before the first frame update


    void Start()
    {
        inventoryToDisable = SaveScript._inventory;
        pressText = SaveScript._readMeText;
        phoneText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (displayText)
                {
                    phoneCanvasIsEnabled = false;
                    phoneText.gameObject.SetActive(false);
                    displayText = false;
                }
                else //turn text on
                {
                    phoneCanvasIsEnabled = true;
                    inventoryToDisable.gameObject.SetActive(false);
                    pressText.gameObject.SetActive(false);
                    displayText = true;
                    phoneText.gameObject.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) ||Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O))
            {
                _disablePhoneCanvas();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        pressText.gameObject.SetActive(true);
        inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        pressText.gameObject.SetActive(false);
        phoneText.gameObject.SetActive(false);
        inRange = false;
    }

    public void _disablePhoneCanvas()
    {
        if(phoneCanvasIsEnabled)
            {
                phoneText.gameObject.SetActive(false);
            }
    }
}
