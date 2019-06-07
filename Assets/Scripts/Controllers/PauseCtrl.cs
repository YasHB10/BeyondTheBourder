using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCtrl : MonoBehaviour{
    private bool isActived;
    public GameObject pausedPanel;
    public GameObject playerBtns;

    void Awake(){
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    public void SetGamePaused(){
        pausedPanel.SetActive(true);
        playerBtns.SetActive(false);
        Time.timeScale = 0;
    }

    public void SetGameActive(){
        playerBtns.SetActive(true);
        pausedPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
