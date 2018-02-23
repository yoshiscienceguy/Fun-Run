using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {
    Transform saveLocation;
	// Use this for initialization
	void Start () {
        saveLocation = GameObject.Find("Respawn").transform;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Vector3 newPos = transform.position;
            newPos.y += 5;
            saveLocation.GetComponent<SavePointController>().MoveLocation(newPos);

        }
    }
}
