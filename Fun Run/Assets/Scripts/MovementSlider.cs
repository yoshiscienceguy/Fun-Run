using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSlider : MonoBehaviour {
    public Transform PointA;
    public Transform PointB;
    private Vector3 current;
    public float speed = 1;
    public bool carryDisable = true;
	// Use this for initialization
	void Start () {
        current = PointA.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, current) > 3)
        {
            transform.position = Vector3.Lerp(transform.position, current, speed * Time.deltaTime);
        }
        else {
            if (current == PointA.position)
            {
                current = PointB.position;
            }
            else {
                current = PointA.position;
            }
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!carryDisable)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(transform);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (!carryDisable)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }
    }
}
