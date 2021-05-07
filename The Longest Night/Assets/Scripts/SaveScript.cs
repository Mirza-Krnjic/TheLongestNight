using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 50;
    public static bool HealthChanged = false;
    public static float batteryPower = 1.0f;
    public static bool flashLightIsOn = false;
    public static bool nightVisionIsOn = false;
    public static int Medkits = 0;
    public static int ammoBoxes = 0;
    public static int baterries = 0;

    //keys
    public static bool RoomKey = false;
    public static bool CabinKey = false;
    public static bool HouseKey = false;
    public static bool CurchKey = false;
}
