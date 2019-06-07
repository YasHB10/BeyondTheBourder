using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDevilCoyote : MonoBehaviour {
    public GameObject []devilCoyotes;
    public GameObject agent;
    public GameObject coyote;
    public Material material;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Invoke("ActiveCoyotes", 0.4f);
        }
    }

    public void ActiveCoyotes() {
        coyote.GetComponent<SkinnedMeshRenderer>().materials[0] = material;
        foreach (GameObject coy in devilCoyotes)
        {
            //coy.GetComponent<PlayerPersecutor>().enabled = true;
            coy.GetComponent<ScorpionBoss>().enabled = true;
        }
        agent.SetActive(true);
    }
}
