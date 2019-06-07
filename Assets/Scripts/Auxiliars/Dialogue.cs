using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogue{
    public string characterName;
    [TextArea(3,10)]
    public string[] dialogue;
}


[Serializable]
public class Dialogues {
    public Dialogue[] dialogues;

    public Dialogue GetDialogue(int index) {
        return dialogues[index];
    }
}
