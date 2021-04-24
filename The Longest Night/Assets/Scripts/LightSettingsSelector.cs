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
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (NightvisionIsActive == false)
            {
                ppVolume.profile = Nightvision;
                NightvisionIsActive = true;
            }
            else
            {
                ppVolume.profile = Standard;
                NightvisionIsActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (spotlightIsActive == false)
            {
                spotlight.enabled = true;
                spotlightIsActive = true;
            }
            else
            {
                spotlight.enabled = false;
                spotlightIsActive = false;
            }
        }
    }
}
