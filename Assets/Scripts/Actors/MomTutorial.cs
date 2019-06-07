using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomTutorial : MonoBehaviour {
    [Header("Values for Mom's movement")]
    [Tooltip("Float value for the horizontal movement.")]
    public float horizontalSpeed;
    public float jumpForceH;
    public float jumpForceV;
    public Transform []positions;

    private int stateTutorial;
    private Rigidbody rigidbody;
    private Animator animator;
    private bool canJump;
    private int indexPos;

    public bool isGrounded;
    // Use this for initialization
    void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        stateTutorial = 0;
        indexPos = 0;
        canJump = true;
	}

    public void MoveToPosition(int index) {
        animator.SetInteger("state", 2);
        transform.position = Vector3.MoveTowards(transform.position, positions[index].position, horizontalSpeed * Time.deltaTime);
    }

    public bool IsOnPosition(int index) {
        //Debug.Log("mom index " + indexPos + " indexpos " +index);
        if (indexPos == index)
        {
            return true;
        }
        else {
            return false;
        }

    }

    public void UpdateIndexPostion(int index) {
        indexPos = index;
        //Debug.Log(indexPos);
    }

    public void Hide() {
        animator.SetInteger("state", 1);
    }

    public void SetStateTutorial(int value) {
        stateTutorial = value;
    }

    public int GetStateTutorial() {
        return stateTutorial;
    }

    public void UpDateState() {
        stateTutorial++;
    }

    public void Jump()
    {
        if (canJump) {
            canJump = false;
            animator.SetInteger("state", 3);
            rigidbody.velocity = new Vector3(jumpForceH, jumpForceV, rigidbody.velocity.z); 
        }
    }

    public void ShowFall() {
        if (rigidbody.velocity.y < 0)
        {
            isGrounded = false;
            animator.SetInteger("state", 5);
            Invoke("ShowLanding", 0.1f);
        }
    }

    public void SetToNormalState() {
        //Debug.Log("set to normal");
        animator.SetInteger("state", 0);
    }

    public bool GetCanJump() {
        return canJump;
    }

    public void ShowLanding()
    {
        animator.SetInteger("state", 6);
    }

    public bool GetIsGrounded() {
        return isGrounded;
    }

    public void flipModelRight() {
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    public void flipModelLeft()
    {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
