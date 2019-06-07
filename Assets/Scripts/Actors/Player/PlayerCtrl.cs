using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls all the  player's actions like
/// jump, hide, walk, die, etc.
/// </summary>
public class PlayerCtrl : MonoBehaviour {
    public SwipeCtrl SwipeCtrl;

    // The original player class' atributes  
    public float horizontalSpeed;
    public float verticalSpeed;
    public float jumpAmplitudeRight;
    public float jumpAmplitudeLeft;
    private int maxHealth, health;

    // theses atributes help to control what actions the player can or can't do
    private bool isAlive;
    private bool isFacingRight;
    private bool isHiding;
    private bool isJumping;
    private bool isNearToHide;
    private bool canMove;
    //GUI bool Ctrl
    private bool rightPressed;
    private bool leftPressed;
    private bool jumpPressed;
    private bool hidePressed;

    //
    private Rigidbody playerRigidbody;
    private Animator anim;

    //public GameObject hideBtn;
    //public GameObject jumpBtn;

    // for testing
    /*
     * public Color defaultColour;
     * public Color isHidingColour;
     * public Color isFacingLef;
     * private Material mat;
    */
    // Use this for initialization
    void Start () {
        jumpPressed = leftPressed = rightPressed = hidePressed = false;
        maxHealth = health = 3;
        isAlive = true;
        isFacingRight = true;
        isHiding = false;
        isJumping = false;
        isNearToHide = false;
        //desiredPosition = new Vector3(3.058216e-08f, 1f, -2f);
        // For 3.058216e-08
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        canMove = true;
        //mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive) {
            // Move Left
            if (canMove) {
                ShowFalling();
                if (leftPressed && !isJumping)
                {
                    if (horizontalSpeed > 0)
                    {
                        horizontalSpeed = -1f * horizontalSpeed;
                    }
                    MoveHorizontal();
                    //mat.color = isFacingLef;
                }
                // Move Right
                if (rightPressed && !isJumping)
                {
                    if (horizontalSpeed < 0)
                    {
                        horizontalSpeed = -1f * horizontalSpeed;
                    }
                    MoveHorizontal();
                    //mat.color = defaultColour;
                }
                // Jump
                if (jumpPressed)
                {
                    Jump();
                }
                //  Hide
                if (hidePressed)
                {

                    Hide();
                }
            }

        }
    }

    public void MoveHorizontal() {
        playerRigidbody.velocity = new Vector3(horizontalSpeed, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        anim.SetInteger("state", 2);
        //Change the orientation of the sprite 
        if (horizontalSpeed < 0)
        {
            /*
            If the player is moving to the left the sprite is facing the lef
            otherwise is facing the right
        */
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            isFacingRight = false;
        }
        else if (horizontalSpeed > 0)
        {
            //sr.flipX = true;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            isFacingRight = true;
        }
    }

    public void StopMoving() {
        playerRigidbody.velocity = new Vector3(0f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        if (!isJumping) {
            // show normal animation state
            anim.SetInteger("state", 0);
        }
    }

    public void Jump() {
        // Limits the jump to one jump
        //float initialPos, finalPos;
        if (!isJumping) {
            isJumping = true;
            isHiding = false;
            anim.SetInteger("state", 3);
            //float auxiliarX = 0, auxiliarHoriVel = 0;
            if (isFacingRight)
            {
                //auxiliarX = transform.position.x + 2.638749f;
                playerRigidbody.velocity = new Vector3(jumpAmplitudeRight, verticalSpeed, playerRigidbody.velocity.z);
            }
            else {
                //auxiliarX = transform.position.x - 2.638749f;
                playerRigidbody.velocity = new Vector3(jumpAmplitudeLeft, verticalSpeed, playerRigidbody.velocity.z);
            }
            //desiredPosition = new Vector3 (auxiliarX, 1f, -2f);
            
        }
    }

    public void Hide() {
        // the player only can hide itself if it is near
        // to a hiding place
        if (isNearToHide) {
            isHiding = true;
            anim.SetInteger("state", 1);
            //mat.color = isHidingColour;
        }
    }

    public void ShowFalling() {
        if (playerRigidbody.velocity.y<0) {
            anim.SetInteger("state", 5);
            Invoke("ShowLanding", 0.1f);
        }
    }

    public void ShowLanding()
    {
        anim.SetInteger("state", 6);
    }

    public void SetIsJumping(bool value) {
        isJumping = value;
    }

    public bool GetIsHiding() {
        return isHiding;
    }

    public void SetIsHiding(bool value) {
        isHiding = value;
    }
    public void SetIsNearToHide(bool value) {
        isNearToHide = value;
    }

    public void SetIsAlive(bool value) {
        isAlive = value;
    }

    public bool GetIsAlive() {
        return isAlive;
    }
   
    public bool GetRightPressed() {
        return rightPressed;
    }

    public bool GetLeftPressed()
    {
        return leftPressed;
    }

    public bool GetJumpPressed()
    {
        return jumpPressed;
    }

    public bool GetHidePressed()
    {
        return hidePressed;
    }

    public bool GetCanMove() {
        return canMove;
    }

    public void SetRightPressed(bool value)
    {
        rightPressed = value;
    }

    public void SetLefPressed(bool value)
    {
        leftPressed = value;
    }

    public void SetJumpPressed(bool value)
    {
        jumpPressed = value;
    }

    public void SetHidePressed(bool value)
    {
        hidePressed = value;
    }

    public void SetCanMove(bool value) {
        canMove = value;
    }

    public bool GetIsfacingRight() {
        return isFacingRight;
    }

    public void SetHealth(float damage) {
        health = (int) Mathf.Clamp((float)health - damage, 0f, (float)maxHealth);
        HealthPlayerUICtrl.healthPlayerUICtrl.UpdateHearts(health);
        if (health == 0) {
            isAlive = false;
            StopMoving();
            StartCoroutine("ShowDeathbyAnimals");
            GameOverCtrl.gameOverCtrl.ShowAnimalGameOver();
        }
    }

    public void HanddleDeath() {
        health = maxHealth;
        isAlive = true;
        //StopMoving();
        anim.SetInteger("state", 0);
        HealthPlayerUICtrl.healthPlayerUICtrl.ReSetHearts();
        transform.position = CheckpointCtrl.checkpointCrl.GetActivePosition();
        ItemCtrl.itemCtrl.ReactiveItems();
        GameOverCtrl.gameOverCtrl.DisenableGameOverPanel();
        leftPressed = false;
        rightPressed = false;
        hidePressed = false;
        jumpPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy_Agent")) {
            StopMoving();
            isAlive = false;
            StartCoroutine("ShowDeathbyAgent");
            GameOverCtrl.gameOverCtrl.ShowAgentGameOver();         
        }
        if (other.gameObject.CompareTag("Enemy_Narco")) {
            StopMoving();
            isAlive = false;
            StartCoroutine("ShowDeathbyNarcos");
            GameOverCtrl.gameOverCtrl.ShowNarcosGameOver();
        }
    }

    public IEnumerator ShowDeathbyAgent() {
        // show animation of that state
        // Invoke the method player dies
        anim.SetInteger("state", 4);
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator ShowDeathbyAnimals()
    {
        // show animation of that state
        // Invoke the method player dies
        anim.SetInteger("state", 4);
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator ShowDeathbyNarcos()
    {
        // show animation of that state
        // Invoke the method player dies
        anim.SetInteger("state", 4);
        yield return new WaitForSeconds(0.2f);
    }

    private void OnTriggerStay(Collider other){
        switch (other.gameObject.tag) {
            case "Hiding_Place":
                if (other.gameObject.GetComponent<HidingPlace>().GetPlayerCanHide())
                {
                    isNearToHide = true;
                    TouchCtrl.touchCtrl.hideBtn.SetActive(true);
                    TouchCtrl.touchCtrl.SetHideActive(true);
                }
                break;
            case "Jump_Area":
                TouchCtrl.touchCtrl.jumpBtn.SetActive(true);
                TouchCtrl.touchCtrl.SetJumpActive(true);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag) {
            case "Hiding_Place":
                isNearToHide = false;
                isHiding = false;
                TouchCtrl.touchCtrl.SetHideActive(false);
                TouchCtrl.touchCtrl.hideBtn.SetActive(false);
                break;
            case "Jump_Area":
                TouchCtrl.touchCtrl.SetJumpActive(false);
                TouchCtrl.touchCtrl.jumpBtn.SetActive(false);
                jumpPressed = false;
                break;
        }
    }
}
