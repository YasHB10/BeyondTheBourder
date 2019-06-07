using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls all the  player's actions like
/// jump, hide, walk, die, etc.
/// </summary>
public class PlayerCtrlcopia : MonoBehaviour {
    public SwipeCtrl SwipeCtrl;

    // The original player class' atributes  
    public float horizontalSpeed;
    public float verticalSpeed;
    public float jumpAmplitudeRight;
    public float jumpAmplitudeLeft;
    private int maxHealth, health;
    private Vector3 desiredPosition;

    // theses atributes help to control what actions the player can or can't do
    private bool isAlive;
    private bool isFacingRight;
    private bool isHiding;
    private bool isJumping;
    private bool isNearToHide;
    

    //
    private Rigidbody playerRigidbody;
    

    // for testing
    public Color defaultColour;
    public Color isHidingColour;
    public Color isFacingLef;
    private Material mat;

    // Use this for initialization
    void Start () {
        maxHealth = health = 3;
        isAlive = true;
        isFacingRight = true;
        isHiding = false;
        isJumping = false;
        isNearToHide = false;
        desiredPosition = new Vector3(3.058216e-08f, 1f, -2f);
        // For 3.058216e-08
        playerRigidbody = GetComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlive) {
            // Move Left
            if (SwipeCtrl.SwipeLeft && !isJumping)
            {
                MoveLetf();
                mat.color = isFacingLef;
            }
            // Move Right
            if (SwipeCtrl.SwipeRight && !isJumping)
            {
                MoveRight();
                mat.color = defaultColour;
            }
            // Jump
            if (SwipeCtrl.SwipeUp)
            {
                Jump();
            }
            //  Hide
            if (SwipeCtrl.SwipeDown)
            {

                Hide();
            }

            if (isJumping == false && isHiding == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, horizontalSpeed * Time.deltaTime);
            }

            if (SwipeCtrl.SwipeLeft == false && SwipeCtrl.SwipeRight == false && SwipeCtrl.SwipeDown == false && SwipeCtrl.SwipeUp == false)
            {
                // Show the normal animation
            }
        }
    }
    
    public void MoveLetf() {
        isFacingRight = false;
        isHiding = false;
        //Flip();
        desiredPosition += (Vector3.left * 2f);  
    }

    public void MoveRight(){
        isFacingRight = true;
        isHiding = false;
        desiredPosition += (Vector3.right * 2f);
        //Flip();
    }

    public void Jump() {
        // Limits the jump to one jump
        //float initialPos, finalPos;
        if (!isJumping) {
            isJumping = true;
            isHiding = false;
            float auxiliarX = 0, auxiliarHoriVel = 0;
            if (isFacingRight)
            {
                auxiliarX = transform.position.x + 2.638749f;
                playerRigidbody.velocity = new Vector3(jumpAmplitudeRight, verticalSpeed, playerRigidbody.velocity.z);
            }
            else {
                auxiliarX = transform.position.x - 2.638749f;
                playerRigidbody.velocity = new Vector3(jumpAmplitudeLeft, verticalSpeed, playerRigidbody.velocity.z);
            }
            desiredPosition = new Vector3 (auxiliarX, 1f, -2f);
            
        }
    }

    public void Hide() {
        // the player only can hide itself if it is near
        // to a hiding place
        if (isNearToHide) {
            isHiding = true;
            mat.color = isHidingColour;
        }
    }

    public void Flip() {
        Vector3 theSacle = transform.localScale;
        theSacle.z *= -1;
        transform.localScale = theSacle;
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

    public void SetHealth(float damage) {
        health = (int) Mathf.Clamp((float)health - damage, 0f, (float)maxHealth);
        HealthPlayerUICtrl.healthPlayerUICtrl.UpdateHearts(health);
        if (health == 0) {
            isAlive = false;
            StartCoroutine("ShowDeathbyAnimals");
            GameOverCtrl.gameOverCtrl.ShowAnimalGameOver();
        }
    }

    public void HanddleDeath() {
        health = maxHealth;
        isAlive = true;
        HealthPlayerUICtrl.healthPlayerUICtrl.ReSetHearts();
        transform.position = CheckpointCtrl.checkpointCrl.GetActivePosition();
        desiredPosition = new Vector3(transform.position.x, 1f, -2f);
        ItemCtrl.itemCtrl.ReactiveItems();
        GameOverCtrl.gameOverCtrl.DisenableGameOverPanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy_Agent")) {
            isAlive = false;
            StartCoroutine("ShowDeathbyAgent");
            GameOverCtrl.gameOverCtrl.ShowAgentGameOver();
            // Handdle dead
            
        }
        if (other.gameObject.CompareTag("Enemy_Narco")) {
            isAlive = false;
            StartCoroutine("ShowDeathbyNarcos");
            GameOverCtrl.gameOverCtrl.ShowNarcosGameOver();
        }
    }

    public IEnumerator ShowDeathbyAgent() {
        // show animation of that state
        // Invoke the method player dies
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator ShowDeathbyAnimals()
    {
        // show animation of that state
        // Invoke the method player dies
        yield return new WaitForSeconds(0.2f);
    }

    public IEnumerator ShowDeathbyNarcos()
    {
        // show animation of that state
        // Invoke the method player dies
        yield return new WaitForSeconds(0.2f);
    }

    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Hiding_Place")){
            if(other.gameObject.GetComponent<HidingPlace>().GetPlayerCanHide())
                isNearToHide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hiding_Place")){
            
            isNearToHide = false;
        }
    }
}
