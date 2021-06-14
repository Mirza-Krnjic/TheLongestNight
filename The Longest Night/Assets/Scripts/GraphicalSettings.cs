using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicalSettings : MonoBehaviour
{
    [SerializeField] GameObject dropDown;

    private void Start()
    {
        if (PlayerPrefs.HasKey("quality"))
        {
            int storedValue = PlayerPrefs.GetInt("quality");

            switch (storedValue)
            {
                case 0:
                    QualitySettings.SetQualityLevel(0);
                    dropDown.GetComponent<Dropdown>().value = 0;
                    break;
                case 1:
                    QualitySettings.SetQualityLevel(1);
                    dropDown.GetComponent<Dropdown>().value = 1;
                    break;
                case 2:
                    QualitySettings.SetQualityLevel(2);
                    dropDown.GetComponent<Dropdown>().value = 2;
                    break;
                case 3:
                    QualitySettings.SetQualityLevel(3);
                    dropDown.GetComponent<Dropdown>().value = 3;
                    break;
                case 4:
                    QualitySettings.SetQualityLevel(4);
                    dropDown.GetComponent<Dropdown>().value = 4;
                    break;
            }
        }
    }

    public void setGraphics()
    {
        int choice = dropDown.GetComponent<Dropdown>().value;
        PlayerPrefs.SetInt("quality", choice);
        int storedValue = PlayerPrefs.GetInt("quality");

        switch (storedValue)
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
