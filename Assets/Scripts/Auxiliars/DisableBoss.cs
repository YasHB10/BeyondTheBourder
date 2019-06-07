using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoss : MonoBehaviour {

    public GameObject scorpionBoss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scorpionBoss.SetActive(false);
        }
    }
}
