using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastendgameTrigger : MonoBehaviour
{
    [SerializeField] GameObject winPannel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
            winPannel.gameObject.SetActive(true);
    }
}
