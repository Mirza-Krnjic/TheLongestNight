using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image batteryImg;
    [SerializeField] float drainTime = 15f;
    [SerializeField] float power;
    void Update()
    {
        if (SaveScript.flashLightIsOn == true || SaveScript.nightVisionIsOn == true)
        {
            batteryImg.fillAmount -= 1f / drainTime * Time.deltaTime;
            power = batteryImg.fillAmount;
            SaveScript.batteryPower = power;
        }
    }
}
