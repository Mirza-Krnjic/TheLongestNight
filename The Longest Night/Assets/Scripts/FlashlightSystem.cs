using System;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightFadeFactor = 1f;
    [SerializeField] float angleFadeFactor = 1f;
    [SerializeField] float minAngle = 40f;
    Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }
    private void Update()
    {
        DecraseLightIntensity();
        DecraseLightAngle();
    }

    private void DecraseLightAngle()
    {
        if (flashlight.spotAngle <= minAngle) return;
        else
            flashlight.spotAngle -= angleFadeFactor * Time.deltaTime;
    }

    private void DecraseLightIntensity()
    {
        flashlight.intensity -= lightFadeFactor * Time.deltaTime;
    }
}
