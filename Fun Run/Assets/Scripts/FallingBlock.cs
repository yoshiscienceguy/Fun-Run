using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {
    public float waitTime = 3f;
    Rigidbody rb;
    bool activated;
    Vector3 returnPosition;
    Quaternion returnRotation;
    bool returnToStart;
    bool movingBack;
    bool rotatingBack;
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        activated = false;
        returnPosition = transform.position;
        returnRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (returnToStart) {
            if (movingBack) {
                transform.position = Vector3.Lerp(transform.position, returnPosition, 3f * Time.deltaTime);
                if (Vector3.Distance(transform.position, returnPosition) < .01) {
                    movingBack = false;
                }
            }


            if (rotatingBack)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, returnRotation, 3f * Time.deltaTime);
                if (Quaternion.Angle(transform.rotation, returnRotation) < 1)
                {
                    rotatingBack = false;
                }
            }

            if (!movingBack && !rotatingBack) {
                activated = false;
                transform.position = returnPosition;
                transform.rotation = returnRotation;
                returnToStart = false;
            }

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated) {
            activated = true;
            StartCoroutine(starTimer());
        }
    }

    IEnumerator starTimer() {

        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        yield return new WaitForSeconds(3f);
        rb.isKinematic = true;
        returnToStart = true;
        movingBack = true;
        rotatingBack = true;
    }
}
