using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the items reactivation after tha player dies 
/// </summary>
public class ItemCtrl : MonoBehaviour {
    public static ItemCtrl itemCtrl;
    private static GameObject[] itemList;
    // Use this for initialization
    private void Awake()
    {
        if (itemCtrl == null) {
            itemCtrl = this;
        }
    }
    void Start () {
        itemList = GameObject.FindGameObjectsWithTag("Item_Health");
        //Debug.Log(itemList.Length);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ReactiveItems() {
        foreach (GameObject aux in itemList) {
            aux.SetActive(true);
        }
    }
}
