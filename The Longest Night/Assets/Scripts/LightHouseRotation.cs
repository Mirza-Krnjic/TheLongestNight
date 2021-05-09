using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseRotation : MonoBehaviour
{
    [SerializeField] GameObject lightHouseLight;
    [SerializeField] float rotationSpeed = 0.1f;

    void Update()
    {
        lightHouseLight.transform.Rotate(0f, rotationSpeed, 0f, Space.World);
    }
}
