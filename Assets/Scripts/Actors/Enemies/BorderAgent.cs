using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class models the boder agent behaviour
/// </summary>
public class BorderAgent : MonoBehaviour {
    private PlayerPersecutor playerPersecutor;
    private AllowerMovement allowerMovement;
    private PatrolingEnemy patrolingEnemy;
    private PatrollingArea patrolliArea;
    [Tooltip ("The agent Game object, this game object has to contain the followed " +
        "componets AllowerMovement, PatrolingEnemy and  PlayerPersecutor")]
    public GameObject PositionsFather;
    [Tooltip ("Enables the patrolling behaviour")]
    public bool canPatrol;
    [Tooltip ("Enables the Chasing bahaviour")]
    public bool isChasing;
    [Tooltip("AllowerMovement than makes true or false the isChasing variable")]
    public AllowerMovement allowerChasing;
    // Use this for initialization

    void Start () {
        allowerMovement = PositionsFather.GetComponent<AllowerMovement>();
        playerPersecutor = GetComponent<PlayerPersecutor>();
        patrolingEnemy = GetComponent<PatrolingEnemy>();
        patrolliArea = PositionsFather.GetComponent<PatrollingArea>();
    }
	
	// Update is called once per frame
	void Update () {
        canPatrol = allowerMovement.Raycasting();
        isChasing = allowerChasing.Raycasting();
        // The agent chases the player
        if (isChasing && !allowerMovement.GetPlayerHidingStatus()){
            patrolingEnemy.AjustModelOrientation(transform.position.x, allowerMovement.GetPlayerPos().x);
            transform.position = playerPersecutor.Chasing(transform.position, allowerMovement.GetPlayerPos());
            HidingPlaceCtrl.hidingPlaceCtrl.DisableHidingPlaces();
            canPatrol = false;
        }
        // the agent patrols
        if (canPatrol){
            patrolingEnemy.UpdatePatrollingOrientation(transform.position.x);
            transform.position = patrolingEnemy.Patrolling(transform.position);
            HidingPlaceCtrl.hidingPlaceCtrl.EnableHidingPlaces();
        }
        // agent comes back to its original position if it leaves the patrolling vision ratio
        if (!patrolliArea.IsAgentOnThePatrollingArea() && !canPatrol && !isChasing) {
            patrolingEnemy.UpdatePatrollingOrientation(transform.position.x);
            transform.position = patrolingEnemy.Patrolling(transform.position);
            HidingPlaceCtrl.hidingPlaceCtrl.EnableHidingPlaces();
        }
	}

}
