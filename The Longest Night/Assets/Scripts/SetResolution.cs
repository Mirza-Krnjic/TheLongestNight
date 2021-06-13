using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    [SerializeField] GameObject dropDown;
    List<int> widths = new List<int>() { 1280, 1366, 1920, 2560 };
    List<int> heights = new List<int>() { 720, 768, 1080, 1440 };


    private void Start()
    {
        if (PlayerPrefs.HasKey("screenIndex"))//if it exists
        {
            int storedIndex = PlayerPrefs.GetInt("screenIndex");
            int width = widths[storedIndex];
            int height = heights[storedIndex];
            Screen.SetResolution(width, height, true);
            dropDown.GetComponent<Dropdown>().value = storedIndex;
        }
    }


    public void SetScreenSize()
    {
        int choice = dropDown.GetComponent<Dropdown>().value;
        PlayerPrefs.SetInt("screenIndex", choice);

        int width = widths[choice];
        int height = heights[choice];

        Screen.SetResolution(width, height, true);
    }
}
