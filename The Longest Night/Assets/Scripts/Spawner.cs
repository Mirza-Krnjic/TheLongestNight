using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawn1;
    [SerializeField] GameObject EnemySpawn2;
    [SerializeField] GameObject EnemySpawn3;

    [SerializeField] Transform SpawnPoint1;
    [SerializeField] Transform SpawnPoint2;
    [SerializeField] Transform SpawnPoint3;
    private bool canSpawn = true;
    [SerializeField] bool multiTrigger = true;

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
                        Instantiate(EnemySpawn1, SpawnPoint1.position, SpawnPoint1.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(EnemySpawn2, SpawnPoint2.position, SpawnPoint2.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(EnemySpawn3, SpawnPoint3.position, SpawnPoint3.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;

                        if (multiTrigger)
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
}
