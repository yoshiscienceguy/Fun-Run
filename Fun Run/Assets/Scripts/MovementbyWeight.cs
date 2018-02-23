using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementbyWeight : MonoBehaviour {

    public float leftRotation = -35f;
    public float rightRotation = 35f;
    public float rotationSpeed = 20f;
    public bool leftTouched;
    public bool rightTouched;
    
    private float destination;
    // Use this for initialization
	void Start () {
        destination = 90;
	}
	
	// Update is called once per frame
	void Update () {

        if (leftTouched)
        {
            destination = leftRotation;
        }
        else if (rightTouched)
        {
            destination = rightRotation;
        }
        else {
            destination = 90;
        }
        if (Quaternion.Angle(transform.rotation, Quaternion.Euler(destination, 0, 0)) > 1) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(destination, 0, 0),rotationSpeed * Time.deltaTime);
        }
		
	}
}
