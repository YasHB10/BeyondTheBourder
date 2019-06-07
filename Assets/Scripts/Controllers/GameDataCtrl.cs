using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// A singletone class than creates GameData file, loads and saves 
/// information on the gamedata file 
/// </summary>
public class GameDataCtrl : MonoBehaviour {
    public static GameDataCtrl instance = null;
    private float restartDelay;
    private GameData data;
    string dataFilePath;
    BinaryFormatter bf;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/gameData.dat";
        Debug.Log(dataFilePath);
        data = new GameData();
    }

    public void ResetData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        LevelData[] levelsInfo = new LevelData[3];
        levelsInfo[0].SetIsUnlocked(true);
        data.SetLevelsData(levelsInfo);
        data.SetLevelsData(levelsInfo);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public void SaveData(int indexUnlokedLevel, int indexConcurrentLevel, float score, float time) {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        data.UnlockLevel(indexUnlokedLevel);
        data.UpdateLevelScore(indexConcurrentLevel, time, score);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public void LoadData() {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            fs.Close();
        }
    }

    public bool DoesGameDataExist()
    {
        if (File.Exists(dataFilePath))
            return true;
        else
            return false;
    }
}
