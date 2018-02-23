using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour {
    private MovementbyWeight mw;
    public bool left;
	// Use this for initialization
	void Start () {
        mw = GetComponentInParent<MovementbyWeight>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (left)
                mw.leftTouched = true;
            else
                mw.rightTouched = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (left)
                mw.leftTouched = false;
            else
                mw.rightTouched = false;
        }
    }


}
