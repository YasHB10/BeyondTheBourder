using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoss : MonoBehaviour {
    public GameObject scorpionBoss;
    private Vector3 bossPos;
    public PlayerCtrl player;

    private void Start()
    {
        bossPos = scorpionBoss.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            scorpionBoss.SetActive(true);
        }    
    }

    private void Update()
    {
        if (!player.GetIsAlive())
        {
            scorpionBoss.transform.position = bossPos;
            scorpionBoss.SetActive(false);
        }
    }
}
