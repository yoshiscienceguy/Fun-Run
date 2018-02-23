using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springblock : MonoBehaviour {
    bool ready;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ready) {
            other.GetComponent<playermovement>().jumpSpeed *= 2;
            ready = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ready)
        {
            ready = false;
            other.GetComponent<playermovement>().jumpSpeed /= 2;
        }
    }
}
