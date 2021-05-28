using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    private EnemyAI enemyAIref;

    private void Start()
    {
        enemyAIref = GetComponent<EnemyAI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyAIref.isActiveAndEnabled == false)
        {
            StartCoroutine(selfdestruct());
        }
    }

    IEnumerator selfdestruct()
    {
        
        yield return new WaitForSeconds(10f);

        Destroy(this.gameObject);
    }
}
