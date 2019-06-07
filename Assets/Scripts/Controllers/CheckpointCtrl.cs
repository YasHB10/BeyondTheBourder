using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCtrl : MonoBehaviour {
    public static GameObject[] checkPointsList;
    public static CheckpointCtrl checkpointCrl; 

    // Use this for initialization
    void Awake () {
        if (checkpointCrl == null) {
            checkpointCrl = this;
        }
    }

    private void Start()
    {
       checkPointsList = GameObject.FindGameObjectsWithTag("Checkpoint");
        //Debug.Log(checkPointsList.Length);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ActivateCheckPoint()
    {
        foreach (GameObject cp in checkPointsList)
        {
            cp.GetComponent<CheckPoint>().setIsActive(false);
        }
        //isActive = true;
    }

    public Vector3 GetActivePosition()
    {
        Vector3 activePosition = new Vector3(0f, 0f, 0f);
        if (checkPointsList != null)
        {
            foreach (GameObject cp in checkPointsList)
            {
                if (cp.GetComponent<CheckPoint>().getIsActive())
                {
                    activePosition = cp.transform.position;
                    break;
                }
            }
        }
        return activePosition;
    }

}
