using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPosition : MonoBehaviour {
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy_Agent":
                other.GetComponent<PatrolingEnemy>().UpdateNextPosition(index, other.gameObject.GetComponent<BorderAgent>().canPatrol);
                break;

            case "EnemyAnimal":
                print("ok ani");
                other.GetComponent<PatrolingEnemy>().UpdateNextPosition(index, other.gameObject.GetComponent<Scorpion>().GetCanPatrol());
                break;

            case "Mom":
                //Debug.Log(other.GetComponent<MomTutorial>().IsOnPosition(index));
                TutorialCtrl.tutorialCtrl.SetMomInPosition(other.GetComponent<MomTutorial>().IsOnPosition(index));
                break;
        }
    }
}
