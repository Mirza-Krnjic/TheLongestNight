using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] GameObject phoneText;
    [SerializeField] GameObject pressText;
    private bool displayText = false;
    private bool inRange = false;
    // Start is called before the first frame update

    void Start()
    {
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
                    phoneText.gameObject.SetActive(false);
                    displayText = false;
                }
                else
                {
                    displayText = true;
                    phoneText.gameObject.SetActive(true);
                }
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
}
