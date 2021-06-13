using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicalSettings : MonoBehaviour
{
    [SerializeField] GameObject dropDown;

    public void setGraphics()
    {
        int choice = dropDown.GetComponent<Dropdown>().value;

        switch(choice)
        {
            case 0:
            QualitySettings.SetQualityLevel(0);
            break;
            case 1:
            QualitySettings.SetQualityLevel(1);
            break;
            case 2:
            QualitySettings.SetQualityLevel(2);
            break;
            case 3:
            QualitySettings.SetQualityLevel(3);
            break;
            case 4:
            QualitySettings.SetQualityLevel(4);
            break;
        }
    }
}
