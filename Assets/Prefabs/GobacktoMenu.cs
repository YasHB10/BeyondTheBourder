using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GobacktoMenu : MonoBehaviour {
    public string nameScene;
	// Use this for initialization
	void Start () {
        Invoke("GoToMenu", 30f);
	}

    public void GoToMenu() {
        SceneManager.LoadScene(nameScene);
    }

	
}
