using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    [SerializeField] GameObject dropDown;
    List<int> widths = new List<int>() { 1280, 1366, 1920, 2560 };
    List<int> heights = new List<int>() { 720, 768, 1080, 1440 };

    public void SetScreenSize()
    {
        int choice = dropDown.GetComponent<Dropdown>().value;
        int width = widths[choice];
        int height = heights[choice];

        Screen.SetResolution(width, height, true);
    }
}
