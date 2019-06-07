using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlaceCtrl : MonoBehaviour {
    private static List<HidingPlace>  hidingPlaces;
    public static HidingPlaceCtrl hidingPlaceCtrl;
    // Use this for initialization
    void Start () {
        hidingPlaces = new List<HidingPlace>();
		GameObject[] auxiliarList = GameObject.FindGameObjectsWithTag("Hiding_Place");
        /*Debug.Log(auxiliarList.Length);
        Debug.Log(auxiliarList[0].transform.position.x);
        Debug.Log(auxiliarList[0].transform.position.y);
        Debug.Log(auxiliarList[0].transform.position.z);*/
        foreach (GameObject aux in auxiliarList) {
            hidingPlaces.Add(aux.GetComponent<HidingPlace>());
        }
        if (hidingPlaceCtrl == null)
        {
            hidingPlaceCtrl = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableHidingPlaces() {
        foreach (HidingPlace auxHiding in hidingPlaces) {
            auxHiding.SetPlayerCanHide(true);
        }
    }

    public void DisableHidingPlaces() {
        foreach (HidingPlace auxHiding in hidingPlaces)
        {
            auxHiding.SetPlayerCanHide(false);
        }
    }
}
