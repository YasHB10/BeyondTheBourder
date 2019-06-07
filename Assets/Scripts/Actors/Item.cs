using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to recover an amount of  health  
/// </summary>
public class Item : MonoBehaviour {
    [Tooltip("Amount of health than the item can restore")]
    [Range (-3,-1)]
    public int healthAmount;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")) {
            other.GetComponent<PlayerCtrl>().SetHealth((float)healthAmount);
            //hasBeenActive = false;
            // Shows the effects
            gameObject.SetActive(false);
        }
    }

}
