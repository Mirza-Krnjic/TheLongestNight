using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsSelector : MonoBehaviour
{
    [SerializeField] PostProcessVolume ppVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile Nightvision;
    [SerializeField] Light spotlight;
    bool NightvisionIsActive = false;
    bool spotlightIsActive = false;

    void Update()
    {
        if (SaveScript.batteryPower > 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (NightvisionIsActive == false)
                {
                    ppVolume.profile = Nightvision;
                    NightvisionIsActive = true;
                    SaveScript.nightVisionIsOn = true;
                }
                else
                {
                    ppVolume.profile = Standard;
                    NightvisionIsActive = false;
                    SaveScript.nightVisionIsOn = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (spotlightIsActive == false)
                {
                    spotlight.enabled = true;
                    spotlightIsActive = true;
                    SaveScript.flashLightIsOn = true;
                }
                else
                {
                    spotlight.enabled = false;
                    spotlightIsActive = false;
                    SaveScript.flashLightIsOn = false;
                }
            }
        }

        if (SaveScript.batteryPower <= 0.0f)
        {
            ppVolume.profile = Standard;
            NightvisionIsActive = false;
            SaveScript.nightVisionIsOn = false;
            spotlight.enabled = false;
            spotlightIsActive = false;
            SaveScript.flashLightIsOn = false;
        }
    }
}
