using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameaFollow : MonoBehaviour {
    public Transform target;
    public float speed = .5f;
    public float rotationSpeed = 5f;
    bool moveRight = false;
    bool moveLeft = false;
    Quaternion left;
    Quaternion right; 
	// Use this for initialization
	void Start () {
        left = Quaternion.Euler(new Vector3(0,-100,0));
        right = Quaternion.Euler(new Vector3(0,-75,0));
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 fixedPosition = target.position;
        fixedPosition.x = transform.position.x;
        transform.position = Vector3.Lerp(transform.position, fixedPosition, speed * Time.deltaTime);

        float h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            moveRight = true;
            moveLeft = false;
        }
        else if (h < 0)
        {
            moveLeft = true;
            moveRight = false;
        }

        if (moveRight)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, right, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, right) < 1){
                moveRight = false;
            }
        }
        if(moveLeft) {
            transform.rotation = Quaternion.Slerp(transform.rotation, left, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, left) < 1)
            {
                moveLeft = false;
            }
        }

	}
}
