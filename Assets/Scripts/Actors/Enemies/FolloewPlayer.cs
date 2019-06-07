using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewPlayer : MonoBehaviour {
    public float speed;
    public float distance;
    private PlayerCtrl player;
    private Animator animator;
    private Vector3 originalPos;
	// Use this for initialization
	void Start () {
        originalPos = transform.position;
        player = FindObjectOfType<PlayerCtrl>().GetComponent<PlayerCtrl>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetIsAlive()) {
            Vector3 aux = new Vector3(player.transform.position.x - distance, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, aux, speed * Time.deltaTime);
            animator.SetInteger("state", 1);
            if (player.transform.position.x - transform.position.x == distance)
            {
                animator.SetInteger("state", 0);
            }

            if (player.GetIsfacingRight())
            {
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
            else {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }
        else{
            transform.position = originalPos;
        }
    }
}
