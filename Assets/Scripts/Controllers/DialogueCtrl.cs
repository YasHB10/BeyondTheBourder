using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCtrl : MonoBehaviour {
    private Queue<string> sentences;
    private bool dialogueActive;

    [Header ("GUI elements for displaying the dialogues")]
    [Tooltip("Text from the Dialogue panel where the name will be displayed.")]
    public Text textName;
    [Tooltip("Text from the Dialogue panel where the dialogue will be displayed.")]
    public Text textDialogue;
    [Tooltip("Panel from the GUI where the dialogues are displayed.")]
    public GameObject dialoguePanel;
    [Tooltip("Panel from the GUI where the pause botton and the player's life is contained.")]
    public GameObject hubPanel;
    //public 

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        dialogueActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StarDialogue(Dialogue dialogue) {
        dialogueActive = true;
        hubPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        sentences.Clear();
        //Debug.Log("Start conversation with " + dialogue.characterName);
        textName.text = dialogue.characterName;
        foreach (string sentence in dialogue.dialogue) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        textDialogue.text = sentence;
        //Debug.Log(sentence);
    }

    public void EndDialogue() {
        //Debug.Log("End of Dialogue");
        dialogueActive = false;
        hubPanel.SetActive(true);
        dialoguePanel.SetActive(false);
    }

    public bool GetDialogueActived() {
        return dialogueActive;
    }
}
