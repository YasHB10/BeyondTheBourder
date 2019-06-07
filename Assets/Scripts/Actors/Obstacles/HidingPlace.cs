using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls if the player can hide
/// </summary>
public class HidingPlace : MonoBehaviour {
    private bool playerCanHide;

	// Use this for initialization
	void Start () {
        playerCanHide = true;	
	}

    public bool GetPlayerCanHide() {
        return playerCanHide;
    }

    public void SetPlayerCanHide(bool value) {
        playerCanHide = value;
    }
	
}
