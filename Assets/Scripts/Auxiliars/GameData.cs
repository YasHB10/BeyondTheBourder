using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// This class contains the player progress data 
/// </summary>
[Serializable]
public class GameData {
    private LevelData[] levelsData = new LevelData[3];

    public LevelData[] GetLevelsData() {
        return levelsData;
    }

    public void SetLevelsData(LevelData[] value)
    {
        levelsData = value;
    }

    public LevelData GetLevelData(int index) {
        return levelsData[index];
    }

    public void SetLevelData(int index, LevelData value) {
        levelsData[index] = value;
    }

    public void UnlockLevel(int index) {
        levelsData[index].SetIsUnlocked(true);
    }

    public void UpdateLevelScore(int index, float time, float scoreN) {
        levelsData[index].SetScore(scoreN);
        levelsData[index].SetTimeCompleted(time);
    }
}

