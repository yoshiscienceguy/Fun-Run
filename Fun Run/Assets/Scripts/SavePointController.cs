using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointController : MonoBehaviour {
    private Vector3 Destination;
    private bool move;
    public float movementSpeed = 3;
    private float currentZ;
    public void MoveLocation(Vector3 newPos) {
        if (currentZ == newPos.z)
            return;
        Destination = newPos;
        newPos += new Vector3(0, 10, 0);
        transform.position = newPos;
        move = true;
        currentZ = newPos.z;

    }
    // Use this for initialization
    void Start () {
        currentZ = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (move) {
            transform.position = Vector3.Lerp(transform.position, Destination, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Destination) < .1f) {
                move = false;
            }
        }
	}
}
