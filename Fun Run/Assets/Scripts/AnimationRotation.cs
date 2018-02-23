using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRotation : MonoBehaviour {
    public float rotationSpeed = 10;
    private float standY = -0.581f;
    private float crouchY = -0.725f;
    public bool StartScreen = false;
    private CharacterController cc;
    // Use this for initialization
    void Start () {
        cc = transform.GetComponentInParent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");

        if (h > 0) {
            float c = 0;
            if (StartScreen) {
                c = 90;
            }
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(new Vector3(0, c, 0))) > 1) {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, c, 0)), rotationSpeed * Time.deltaTime);
            }
        }
        else if (h < 0)
        {
            float c = -180;
            if (StartScreen)
                c = -90;
            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(new Vector3(0,c,0))) > 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, c, 0)), rotationSpeed * Time.deltaTime);
            }
        }

        //if (Input.GetAxis("Crouch") > 0)
        //{
        //    transform.localPosition = new Vector3(transform.localPosition.x, crouchY, transform.localPosition.z);
        //    cc.height = 1.25f;
        //    cc.center = new Vector3(0, -0.38f,0);
            
        //}
        //else {
        //    transform.localPosition = new Vector3(transform.localPosition.x, standY, transform.localPosition.z);
        //    cc.height = 1.8f;
        //    cc.center = new Vector3(0, 0, 0);
        //}
    }
}
