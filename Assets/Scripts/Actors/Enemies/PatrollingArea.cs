using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingArea : MonoBehaviour {
    public float visionRadius;
    public GameObject agent;
    private Vector3 initialPosition;
    // Use this for initialization

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    public bool IsAgentOnThePatrollingArea()
    {
        Vector3 target = initialPosition;
        float dist = Vector3.Distance(agent.transform.position, transform.position);
        
        if (dist < visionRadius)
        {
            target = agent.transform.position;
            //Debugs the target position whit a green line
            Debug.DrawLine(transform.position, target, Color.green);
            return true;

        }
        else
        {
            //Debugs the target position whit a green line
            Debug.DrawLine(transform.position, target, Color.green);
            return false;
        }
    }

    /// <summary>
    /// Draws the active area
    /// </summary>
    void OnDrawGizmos()
    {

        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

    }
}
