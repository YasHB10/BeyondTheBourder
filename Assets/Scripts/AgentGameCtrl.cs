using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGameCtrl : MonoBehaviour {
    public Transform playerPosition;
    private PlayerPersecutor playerPersecutor;
	// Use this for initialization
	void Start () {
        playerPersecutor = GetComponent<PlayerPersecutor>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerPersecutor.Chasing(transform.position, playerPosition.position);

    }
}
