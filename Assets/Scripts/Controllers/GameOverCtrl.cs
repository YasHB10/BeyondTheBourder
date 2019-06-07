using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCtrl : MonoBehaviour {
    [Header("GameObject/GUI Panels")]
    public GameObject panelGameOver;
    public GameObject playerBottons;
    public static GameOverCtrl gameOverCtrl;
    [Header("Images/Sprites")]
    [Tooltip ("Image from the GameOver panel")]
    public Image gameOverImage;
    public Sprite animalsEnding;
    public Sprite agentsEnding;
    public Sprite narcosEnding;

    // Use this for initialization
    void Awake () {
        panelGameOver.SetActive(false);
        if (gameOverCtrl == null) {
            gameOverCtrl = this;
        }
    }

    public void ShowAnimalGameOver()
    {   
        playerBottons.SetActive(false);
        Invoke("ShowGameOverPanel", 0.6f);
        gameOverImage.sprite = animalsEnding;
    }

    public void ShowAgentGameOver()
    {
        playerBottons.SetActive(false);
        Invoke("ShowGameOverPanel", 0.6f);
        gameOverImage.sprite = agentsEnding;
    }

    public void ShowNarcosGameOver()
    {
        playerBottons.SetActive(false);
        Invoke("ShowGameOverPanel", 0.6f);
        gameOverImage.sprite = narcosEnding;
    }

    public void DisenableGameOverPanel()
    {
        panelGameOver.SetActive(false);
        playerBottons.SetActive(true);
    }

    public void ShowGameOverPanel() {
        panelGameOver.SetActive(true);
    }
}
