using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralHealthbar : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] Transform sliderValue;
    private float convertedPlayerHealth;
    void Start()
    {
        playerHealth = SaveScript.PlayerHealth;
        sliderValue.localScale = new Vector3(1f, 1f, 1f);
        convertedPlayerHealth = (float)(playerHealth / 100f);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = SaveScript.PlayerHealth;
        convertedPlayerHealth = (float)(playerHealth / 100f);
        sliderValue.localScale = new Vector3(convertedPlayerHealth, 1f, 1f);
    }
}
