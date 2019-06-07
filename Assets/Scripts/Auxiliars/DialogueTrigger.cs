using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Dialogue dialogue;
	
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueCtrl>().StarDialogue(dialogue);
    }

    public void SetDialogue(Dialogue value) {
        dialogue = value;
    }
}
