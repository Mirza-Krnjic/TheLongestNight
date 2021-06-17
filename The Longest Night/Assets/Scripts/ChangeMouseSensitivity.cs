using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMouseSensitivity : MonoBehaviour
{
    [SerializeField] Slider mouuseSendSlider;
    [SerializeField] FirstPersonAIO playerController;
    public void ChangeMouseSensitivitySlider()
    {
        playerController.mouseSensitivity = mouuseSendSlider.value;
    }
}
