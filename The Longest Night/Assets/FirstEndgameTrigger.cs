using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstEndgameTrigger : MonoBehaviour
{
    [SerializeField] GameObject nextObjective;
    [SerializeField] GameObject prevObjective;
    [SerializeField] GameObject endgameCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {

            prevObjective.gameObject.SetActive(false);
            nextObjective.gameObject.SetActive(true);
            endgameCollider.gameObject.SetActive(true);
        }
    }
}
