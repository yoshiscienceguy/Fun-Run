using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
    public Vector3 StartRotation;
    public Vector3 EndRotation;
    private Vector3 destination;
    private Vector3 toMeasure;
    public float RotationSpeed = 30f;
    public bool inverted = false;
    // Use this for initialization
    void Start () {

        destination = Vector3.forward;
        if (inverted)
            destination *= -1;
        toMeasure = StartRotation;

    }
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(Quaternion.Angle(transform.rotation, Quaternion.Euler(toMeasure))) < 5)
        {
            if (toMeasure == StartRotation)
            {
                toMeasure = EndRotation;
                destination = Vector3.back;
            }
            else
            {
                toMeasure = StartRotation;
                destination = Vector3.forward;
            }
            if (inverted)
                destination *= -1;
        }

        transform.Rotate(destination * RotationSpeed * Time.deltaTime);
        
		
	}
}
