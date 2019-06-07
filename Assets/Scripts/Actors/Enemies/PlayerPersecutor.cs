using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class models the chasing behaiour
/// </summary>
public class PlayerPersecutor : MonoBehaviour {
    [Tooltip("float value. Speed of the enemy's persecution")]
    public float speed;

    /// <summary>
    /// Makes an Enemy chasing a target
    /// </summary>
    /// <param name="AgentPosition"> Enemy's position</param>
    /// <param name="TargetPos"> Chasing target </param>
    /// <returns>Returns the Enemy new position</returns>
    public Vector3 Chasing(Vector3 AgentPosition, Vector3 TargetPos){
        //isChasingPlayer = true;
        float fixedSpeed = speed * Time.deltaTime;
        TargetPos.y = AgentPosition.y;
        AgentPosition = Vector3.MoveTowards(AgentPosition, TargetPos, fixedSpeed);
        return AgentPosition;
    }
}
