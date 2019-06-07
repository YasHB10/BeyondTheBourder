using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour {
    public int nextState;
    public bool ChangesState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ChangesState)
            {
                TutorialCtrl.tutorialCtrl.UpdateMomState(nextState);
            }
            else {
                TutorialCtrl.tutorialCtrl.SetMarcosArchived(true);
            }
        }
    }
}
