using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCube : MonoBehaviour {
    public float spinSpeed = 5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0,spinSpeed * Time.deltaTime, 0);
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<playermovement>().ReturntoPoint();
        }
    }
}
