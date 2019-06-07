using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Allows a Player to appear in a certain position after dying.
/// </summary>
public class CheckPoint : MonoBehaviour {
    //private Animator anim;
    public bool isActive;

    public void setIsActive(bool value)
    {
        isActive = value;
    }

    public bool getIsActive()
    {
        return isActive;
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //anim.SetInteger("state", 1);
            CheckpointCtrl.checkpointCrl.ActivateCheckPoint();
            isActive = true;
            //Debug.Log("Working");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //anim.SetInteger("state", 0);
        }
    }
}
