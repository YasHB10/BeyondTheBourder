using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour {
    public AllowerMovement allowerMovement;
    private PatrolingEnemy patrolingEnemy;
    private Animator animator;
    private bool canPatrol;

	// Use this for initialization
	void Start () {
        canPatrol = false;
        patrolingEnemy = gameObject.GetComponent<PatrolingEnemy>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        canPatrol = allowerMovement.Raycasting();
        if (canPatrol)
        {
            print("y");
            transform.position = patrolingEnemy.Patrolling(transform.position);
            animator.SetInteger("state", 1);
        }
        else {
            animator.SetInteger("state", 0);
        }
	}

    public bool GetCanPatrol() {
        return canPatrol;
    }
}
