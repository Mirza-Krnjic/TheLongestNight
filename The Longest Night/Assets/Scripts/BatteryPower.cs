using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image batteryImg;
    [SerializeField] float FlashlightdrainTime = 40f;
    [SerializeField] float nightVisiondrainTime = 40f;
    [SerializeField] float power;
    void Update()
    {
        if (SaveScript.flashLightIsOn == true)
        {
            batteryImg.fillAmount -= 1f / FlashlightdrainTime * Time.deltaTime;

            power = batteryImg.fillAmount;
            SaveScript.batteryPower = power;
        }
        else if (SaveScript.nightVisionIsOn == true)
        {
            batteryImg.fillAmount -= 1f / nightVisiondrainTime * Time.deltaTime;

            power = batteryImg.fillAmount;
            SaveScript.batteryPower = power;
        }
    }
}
