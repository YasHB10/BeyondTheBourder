using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class checks if the player is near for 
/// </summary>
public class AllowerMovement : MonoBehaviour {
    [Tooltip("float value. This value represents the position where the bullet will be created when the enemy shoots")]
    public float visionRadius;
    private GameObject player;
    private Vector3 initialPosition;
    // Use this for initialization

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    /// <summary>
    /// Checks if the player is inside the active area
    /// </summary>
    /// <returns></returns>
    public bool Raycasting() {
        Vector3 target = initialPosition;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Debug.DrawLine(transform.position, target, Color.green);
        if (dist < visionRadius){
            target = player.transform.position;
            if (player.GetComponent<PlayerCtrl>().GetIsAlive())
            {
                return true;
            }
            else {
                return false;
            }
            
        }
        else{
            return false;
        }

        //Debugs the target position whit a green line
        //Debug.DrawLine(transform.position, target, Color.green);
    }

    /// <summary>
    /// Gets the concurrent player position
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPlayerPos() {
        return player.transform.position;
    }

    /// <summary>
    /// Gets the concurrent Player hiding status
    /// </summary>
    /// <returns></returns>
    public bool GetPlayerHidingStatus() {
        return player.GetComponent<PlayerCtrl>().GetIsHiding();
    }

    /// <summary>
    /// Draws the active area
    /// </summary>
    void OnDrawGizmos(){

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

    }
}
