using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrink : MonoBehaviour {
    public float shrinkSpeed = 3;
    public float StartDelay = 1f;
    public float shrinkSize = .01f;
    private float currentDelay = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentDelay < StartDelay)
        {
            currentDelay += Time.deltaTime;
        }
        else {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * shrinkSize, shrinkSpeed * Time.deltaTime);
        }
	}
}
