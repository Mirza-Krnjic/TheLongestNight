using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    public static GameObject _inventory;
    [SerializeField] GameObject readMeText;
    public static GameObject _readMeText;
    [SerializeField] GameObject hurtImageGameObject;
    [SerializeField] GameObject[] enemyModels;
    public static GameObject[] enemies;

    public static int PlayerHealth = 100;
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

    public static bool newGame = false;

    [SerializeField] Transform playerLocation;
    [SerializeField] Animator EnemyhurtAnim;
    [SerializeField] AudioSource EnemyHitSound;
    [SerializeField] AudioClip[] zombieSounds;
    public static int soundsAryZize;
    public static AudioClip[] _zombieSounds;

    public static Transform targetPlayer;
    public static Animator hurtAnim;
    public static AudioSource hitSound;

    public static int maxEnemiesOnScreen = 6;
    public static int enemiesOnScreen = 0;
    public static int maxEnemiesInGame = 100;
    public static int enemiesCurrent = 0;


    private void Awake()
    {
        _inventory = inventory;
        _readMeText = readMeText;

        hurtImageGameObject.gameObject.SetActive(true);
        enemies = enemyModels;
        _zombieSounds = zombieSounds;
        soundsAryZize = zombieSounds.Length;

        targetPlayer = playerLocation;
        hurtAnim = EnemyhurtAnim;
        hitSound = EnemyHitSound;
        if (newGame)
        {
            Time.timeScale = 1f;
            PlayerHealth = 100;
            HealthChanged = false;
            batteryPower = 1.0f;
            flashLightIsOn = false;
            nightVisionIsOn = false;
            Medkits = 0;
            ammoBoxes = 0;
            baterries = 0;

            //keys
            RoomKey = false;
            CabinKey = false;
            HouseKey = false;
            CurchKey = false;

        }
    }
}
