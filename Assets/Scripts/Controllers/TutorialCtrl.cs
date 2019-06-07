using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class TutorialCtrl : MonoBehaviour {
    private DialogueCtrl dialogueCtrl;
    public MomTutorial mom;
    public PlayerCtrl playerCtrl;
    public Dialogues dialogues;
    public static TutorialCtrl tutorialCtrl;
    private bool marcosArchived;
    private bool momInPosition;
    public GameObject item;
    public CheckPoint checkpoint;
    public string sceneName;


	// Use this for initialization
	void Start () {
        if (tutorialCtrl == null) {
            tutorialCtrl = this;
        }
        dialogueCtrl = gameObject.GetComponent<DialogueCtrl>();
        marcosArchived = false;
	}
	
	// Update is called once per frame
	void Update () {
        switch (mom.GetStateTutorial()) {
            // The mother explains how to move
            case 0:
                //Debug.Log(dialogueCtrl.GetDialogueActived());
                if (!marcosArchived) {
                    marcosArchived = true;
                    playerCtrl.SetCanMove(false);
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(0));
                }
                if(!dialogueCtrl.GetDialogueActived())
                {
                    mom.flipModelRight();
                    playerCtrl.SetCanMove(true);
                }
                break;
            // The mother explains how to hide
            case 1:

                //Debug.Log(momInPosition + " " + marcosArchived);
                if (!momInPosition)
                {
                    mom.MoveToPosition(0);
                }

                if (momInPosition && marcosArchived)
                {
                    mom.SetToNormalState();
                    marcosArchived = false;
                    playerCtrl.SetCanMove(false);
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(1));
                }
                
                if (!marcosArchived && !dialogueCtrl.GetDialogueActived()) {
                    playerCtrl.SetCanMove(true);
                    //mom.flipModelRight();
                    mom.SetStateTutorial(2);
                }
                break;
            // the mother congratulates marcos for hiding
            case 2:
                if (!marcosArchived) {
                    mom.Hide();
                    marcosArchived = true;
                }
                if (playerCtrl.GetIsHiding() && playerCtrl.GetCanMove()) {
                    marcosArchived = false;
                    playerCtrl.SetCanMove(false);
                    //mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(2));
                }
                if (!playerCtrl.GetCanMove()&&!dialogueCtrl.GetDialogueActived()) {
                    //Debug.Log("Se acabo dialogo");
                    playerCtrl.SetCanMove(true);
                    mom.UpdateIndexPostion(1);
                    momInPosition = false;
                    marcosArchived = false;
                    mom.flipModelRight();
                    mom.SetStateTutorial(3);
                }
                break;
            // Mother explains how to jump and jumps
            case 3:
                if (!momInPosition)
                {
                    mom.MoveToPosition(1);
                }
                else if (marcosArchived)
                {
                    mom.SetToNormalState();
                    marcosArchived = false;
                    playerCtrl.SetCanMove(false);
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(3));
                }
                else {
                    mom.SetToNormalState();
                }
                if (!marcosArchived && momInPosition && !playerCtrl.GetCanMove()&& !dialogueCtrl.GetDialogueActived())
                {
                    mom.flipModelRight();
                    mom.Jump();
                }

                if (!mom.GetCanJump()&& mom.GetIsGrounded()) {
                    //playerCtrl.SetCanMove(false);
                    mom.SetToNormalState();
                    mom.UpdateIndexPostion(2);
                    momInPosition = false;
                    mom.SetStateTutorial(4);
                }
                break;
            // the mother congratulates marcos for jumping
            case 4:
                if (!momInPosition)
                {
                    mom.MoveToPosition(2);
                }
                else {
                    mom.SetToNormalState();
                    playerCtrl.SetCanMove(true);
                }

                if (playerCtrl.GetJumpPressed()) {
                    marcosArchived = true;
                    playerCtrl.SetCanMove(false);
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(4));
                }

                if (marcosArchived && !dialogueCtrl.GetDialogueActived()) {
                    mom.flipModelRight();
                    mom.UpdateIndexPostion(3);
                    momInPosition = false;
                    marcosArchived = false;
                    mom.SetStateTutorial(5);
                    playerCtrl.SetCanMove(true);
                }
                break;
            case 5:
                if (!momInPosition)
                {
                    mom.MoveToPosition(3);
                }
                else {
                    mom.SetToNormalState();
                }

                if (marcosArchived && playerCtrl.GetCanMove()) {
                    playerCtrl.SetCanMove(false);
                    marcosArchived = false;
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(5));
                }

                if (!marcosArchived && !playerCtrl.GetCanMove()&& !dialogueCtrl.GetDialogueActived()) {
                    playerCtrl.SetCanMove(true);
                }
                if (playerCtrl.GetCanMove() && !dialogueCtrl.GetDialogueActived() && !item.activeInHierarchy) {
                    mom.flipModelRight();
                    mom.UpdateIndexPostion(4);
                    momInPosition = false;
                    mom.SetStateTutorial(6);
                }
                break;
            case 6:
                if (!momInPosition)
                {
                    mom.MoveToPosition(4);
                }
                else
                {
                    mom.SetToNormalState();
                }

                if (marcosArchived && playerCtrl.GetCanMove())
                {
                    playerCtrl.SetCanMove(false);
                    marcosArchived = false;
                    mom.flipModelLeft();
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(6));
                }

                if (!marcosArchived && !playerCtrl.GetCanMove() && !dialogueCtrl.GetDialogueActived())
                {
                    playerCtrl.SetCanMove(true);
                }
                if (playerCtrl.GetCanMove() && !dialogueCtrl.GetDialogueActived() && checkpoint.getIsActive())
                {
                    mom.UpdateIndexPostion(5);
                    playerCtrl.SetCanMove(false);
                    momInPosition = false;
                    mom.SetStateTutorial(7);
                }
                break;
            case 7:
                if (!marcosArchived)
                {
                    marcosArchived = true;
                    dialogueCtrl.StarDialogue(dialogues.GetDialogue(7));
                }
                else {
                    //Debug.Log("Tutorial terminado");
                    SceneManager.LoadScene(sceneName);
                }
                break;
        }
	}

    public void UpdateMomState(int value) {
        mom.SetStateTutorial(value);
    }

    public void SetMomInPosition(bool value) {
        momInPosition = value;
    }

    public void SetMarcosArchived(bool value) {
        marcosArchived = value;
    }
}
