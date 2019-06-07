using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The patroling behavior of an enemy
/// </summary>
public class PatrolingEnemy : MonoBehaviour {
    [Tooltip ("Transform array for the movement")]
    public Transform[] movingPos;
    [Tooltip("A float value for the speed movement")]
    public float speed;
    private int controlNumber;
    private Vector3 nextPos;
    public bool isGoingRight;
    //public bool isGoingRightAux;


    void Awake () {
        //isGoingRightAux = isGoingRight;
        if (isGoingRight){
            RestartMovement();
        }
        else {
            ReverseMovement();
        }
	}	


    /// <summary>
    /// Restarts the movement to the right
    /// </summary>
    public void RestartMovement() {
        isGoingRight = true;
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        nextPos = movingPos[1].position;
        controlNumber = 1;
    }
    /// <summary>
    /// Restarts the movement to the left
    /// </summary>
    public void ReverseMovement(){
        isGoingRight = false;
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        nextPos = movingPos[movingPos.Length - 1].position;
        controlNumber = movingPos.Length - 1;
    }


    public bool GetIsGoingRight() {
        return isGoingRight;
    }

    public void SetIsGoingRight(bool value) {
        isGoingRight = value;
    }

    /// <summary>
    /// Gets the next position for the patrolling
    /// </summary>
    /// <returns></returns>
    public Vector3 GetNextPosition() {
        return nextPos;
    }

    /// <summary>
    /// Updates the next position depending on the agente direction
    /// </summary>
    /// <param name="positionAgent"></param>
    public void UpdateNextPositition(float positionAgent) {
        //Debug.Log("ok2");
        if (positionAgent == nextPos.x)
        {
            if (controlNumber == movingPos.Length - 1)
            {
                ReverseMovement();
            }
            if (controlNumber == 0)
            {
                RestartMovement();
            }

            if (isGoingRight)
            {
                controlNumber++;
            }
            else
            {
                controlNumber--;
            }
            nextPos = movingPos[controlNumber].position;
            Debug.Log(controlNumber);
        }
    }


    public void UpdatePairPatroling(int index, bool isPatroling)
    {
        if (isPatroling) {

        }
    }

    public void UpdateNextPosition(int index, bool isPatroling) {
        //print(isPatroling);
        if (isPatroling)
        {
            //print(controlNumber);
            //print(index);
            if (index == controlNumber)
            {
                if (controlNumber == movingPos.Length - 1)
                {
                    ReverseMovement();
                }
                if (controlNumber == 0)
                {
                    RestartMovement();
                }
                else {
                    if (isGoingRight)
                    {
                        controlNumber++;
                    }
                    else
                    {
                        controlNumber--;
                    }
                }

                
                
                nextPos = movingPos[controlNumber].position;
            }
        }
        else {
            nextPos = movingPos[index].position;
        }
        
    }






    /// <summary>
    /// Patrol behaviour
    /// </summary>
    /// <param name="PositionAgent"></param>
    /// <returns></returns>
    public Vector3 Patrolling(Vector3 PositionAgent) {
        Vector3 NewPosition = Vector3.MoveTowards(PositionAgent, nextPos, speed * Time.deltaTime);
        //Debug.Log(controlNumber);
        return NewPosition;
    }
    /// <summary>
    /// Updates the patrolling orientation depending on the next position
    /// </summary>
    /// <param name="AgentPosX"></param>
    public void UpdatePatrollingOrientation(float AgentPosX) {
        if (Mathf.Sign(AgentPosX - nextPos.x) == 1)
        {
            isGoingRight = false;
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Mathf.Sign(AgentPosX - nextPos.x) == -1)
        {
            isGoingRight = true;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    /// <summary>
    /// Ajusts the agent orientation depending on the player position
    /// </summary>
    /// <param name="AgentPosX"></param>
    /// <param name="PlayerPosX"></param>
    public void AjustModelOrientation(float AgentPosX,float PlayerPosX) {
        if (Mathf.Sign(AgentPosX - PlayerPosX) == 1)
        {
            isGoingRight = false;
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Mathf.Sign(AgentPosX - PlayerPosX) == -1)
        {
            isGoingRight = true;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.gray;
        Gizmos.DrawLine(movingPos[0].position, movingPos[movingPos.Length-1].position);

    }
}
