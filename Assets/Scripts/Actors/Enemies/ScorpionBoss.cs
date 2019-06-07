using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionBoss : MonoBehaviour {
    //public float NormalSpeed;
    //public float JumpPlayerSpeed;
    private PlayerCtrl player;
    private PlayerPersecutor playerPersecutor;
    private Animator animator;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerCtrl>().GetComponent<PlayerCtrl>();
        playerPersecutor = gameObject.GetComponent<PlayerPersecutor>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetInteger("state", 1);
        transform.position = playerPersecutor.Chasing(transform.position, player.transform.position);
        animator.SetInteger("state", 1);
	}
}
