using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelData {
    private float timeCompleted;
    private float score;
    private bool isUnlocked;

    public float GetTimeCompleted()
    {
        return timeCompleted;
    }

    public float GetScore()
    {
        return score;
    }

    public bool GetIsUnlocked()
    {
        return isUnlocked;
    }

    public void SetTimeCompleted(float value)
    {
        timeCompleted = value;
    }

    public void SetScore(float value)
    {
        score = value;
    }

    public void SetIsUnlocked(bool value)
    {
        isUnlocked = value;
    }
}
