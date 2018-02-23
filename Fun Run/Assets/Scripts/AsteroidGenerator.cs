using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {
    public GameObject Asteroid;
    public float width;
    public float frequency;
    private float currentAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentAmount < frequency)
        {
            currentAmount += Time.deltaTime;
        }
        else {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, Random.Range(-width, width) + transform.position.z);
            Instantiate(Asteroid, newPos, transform.rotation);
            currentAmount = 0;
        }
	}
}
