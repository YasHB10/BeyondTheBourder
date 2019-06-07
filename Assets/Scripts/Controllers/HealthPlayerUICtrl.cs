using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayerUICtrl : MonoBehaviour {
    public HealthPlayerUI healthPlayerUI;
    public static HealthPlayerUICtrl healthPlayerUICtrl;
    // Use this for initialization
    private void Awake()
    {
        if (healthPlayerUICtrl == null)
        {
            healthPlayerUICtrl = this;
        }
    }


    public void UpdateHearts(float health) {
        if (health == 3)
        {
            healthPlayerUI.heart3.sprite = healthPlayerUI.fullHeart;
            healthPlayerUI.heart2.sprite = healthPlayerUI.fullHeart;
            healthPlayerUI.heart1.sprite = healthPlayerUI.fullHeart;
        }

        if (health == 2)
        {
            healthPlayerUI.heart3.sprite = healthPlayerUI.fullHeart;
            healthPlayerUI.heart2.sprite = healthPlayerUI.fullHeart;
            healthPlayerUI.heart1.sprite = healthPlayerUI.emptyHeart;
        }

        if (health == 1)
        {
            healthPlayerUI.heart3.sprite = healthPlayerUI.fullHeart;
            healthPlayerUI.heart1.sprite = healthPlayerUI.emptyHeart;
            healthPlayerUI.heart2.sprite = healthPlayerUI.emptyHeart;
        }

        if (health == 0) {
            healthPlayerUI.heart1.sprite = healthPlayerUI.emptyHeart;
            healthPlayerUI.heart2.sprite = healthPlayerUI.emptyHeart;
            healthPlayerUI.heart3.sprite = healthPlayerUI.emptyHeart;
        }
    }

    public void ReSetHearts() {
        healthPlayerUI.heart3.sprite = healthPlayerUI.fullHeart;
        healthPlayerUI.heart2.sprite = healthPlayerUI.fullHeart;
        healthPlayerUI.heart1.sprite = healthPlayerUI.fullHeart;
    }

    /*public void EnableGameOverPanel() {
        healthPlayerUI.panelGameOver.SetActive(true);
    }

    public void DisenableGameOverPanel()
    {
        healthPlayerUI.panelGameOver.SetActive(false);
    }*/

}
