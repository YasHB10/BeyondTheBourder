using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {
    public string sceneName;
    PlayerCtrl player;
    bool restartGame;

    private void Start()
    {
        player = FindObjectOfType<PlayerCtrl>().GetComponent<PlayerCtrl>();
    }

    private void Update()
    {
        if (player.GetLeftPressed() || player.GetRightPressed() || player.GetJumpPressed() || player.GetHidePressed())
        {
            CancelInvoke("RestarGame");
        }
        else {
            //print("Invoke");
            Invoke("RestarGame", 120f);
        }
    }

    public void RestarGame()
    {
        SceneManager.LoadScene("00_MenuPrincipal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
