using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject EnemySpawn1;
    private GameObject EnemySpawn2;
    private GameObject EnemySpawn3;

    [SerializeField] GameObject[] enemies;

    [SerializeField] Transform SpawnPoint1;
    [SerializeField] Transform SpawnPoint2;
    [SerializeField] Transform SpawnPoint3;
    private bool canSpawn = true;
    [SerializeField] int spawnTimes = 3;
    private int timesSpawned = 0;
    [SerializeField] bool multiTrigger = true;

    private void Start()
    {
        GenerateEnemyTypes();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(SaveScript.enemiesOnScreen);
        if (other.gameObject.CompareTag("Player"))
        {
            if (SaveScript.enemiesCurrent < SaveScript.maxEnemiesInGame)
            {
                if (SaveScript.enemiesOnScreen < SaveScript.maxEnemiesOnScreen)
                {
                    if (canSpawn)
                    {
                        canSpawn = false;
                        timesSpawned++;
                        GenerateEnemyTypes();

                        Instantiate(EnemySpawn1, SpawnPoint1.position, SpawnPoint1.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(EnemySpawn2, SpawnPoint2.position, SpawnPoint2.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(EnemySpawn3, SpawnPoint3.position, SpawnPoint3.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;

                        if (multiTrigger && timesSpawned <= spawnTimes)
                        {
                            StartCoroutine(WaitToSpawn());
                        }
                    }
                }
            }
        }
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(2f);
        canSpawn = true;
    }

    private void GenerateEnemyTypes()
    {
        EnemySpawn1 = SaveScript.enemies[Random.Range(0, SaveScript.enemies.Length - 1)];
        EnemySpawn2 = SaveScript.enemies[Random.Range(0, SaveScript.enemies.Length - 1)];
        EnemySpawn3 = SaveScript.enemies[Random.Range(0, SaveScript.enemies.Length - 1)];
    }
}
