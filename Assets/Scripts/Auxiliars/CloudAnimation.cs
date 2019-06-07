using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimation : MonoBehaviour {
    public float speed;
    public Transform Pos01;
    public Transform Pos02;
    public bool canMove;
    private Vector3 goNext;
    // Update is called once per frame

    private void Start()
    {
        goNext = new Vector3(Pos02.position.x, transform.position.y, transform.position.z);  
    }

    void Update () {
        if (canMove) {
            if (transform.position.x == Pos01.position.x) {
                goNext = new Vector3(Pos02.position.x, transform.position.y, transform.position.z);
            } else if (transform.position.x == Pos02.position.x) {
                transform.position = new Vector3(Pos01.position.x, transform.position.y, transform.position.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, goNext, speed * Time.deltaTime);
        }
	}
}
