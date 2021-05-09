using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float zoomedOutLevel = 60f;
    [SerializeField] float zoomedInLevel = 20f;
    bool isZoomed = false;

    private void OnDisable()
    {
        isZoomed = false;
        cam.fieldOfView = zoomedOutLevel;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomed == false)
            {
                isZoomed = true;
                cam.fieldOfView = zoomedInLevel;
            }
            else
            {
                isZoomed = false;
                cam.fieldOfView = zoomedOutLevel;
            }
        }
    }
}
