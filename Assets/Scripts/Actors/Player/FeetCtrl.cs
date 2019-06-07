using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {
    private PlayerCtrl player;
    public Transform dustParticlePos;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Ground")){
            player.SetIsJumping(false);
            //VFXCtrl.VFXCtrlInstance.ShowPlayerLanding(dustParticlePos.position);
        }
    }
}
