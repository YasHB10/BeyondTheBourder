using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {
    public float RotationSpeed;
    public bool RotationX, RotationY, RotationZ;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (RotationX)
        {
            transform.Rotate(Vector3.right * (RotationSpeed * Time.deltaTime));
        }
        else if (RotationY)
        {
            transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        } else if (RotationZ)
        {
            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        }
        
    }
}
