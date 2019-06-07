using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [Tooltip ("Amout of damage than the enemy can infringe upon the player")]
    [Range (1,3)]
    public int damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player" )) {
            other.SendMessage("SetHealth", (float)damageAmount);
        }
    }
}
