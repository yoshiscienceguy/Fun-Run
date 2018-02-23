using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merrygoround : MonoBehaviour {

    public float angle = 0;
    public float speed = 3;  //2*PI in degress is 360, so you get 5 seconds to complete a circle
    public float radius = 5;
    void Update()
    {
        if (angle > 6.283f) {
            angle = 0;
        }
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.GetChild(0).transform.position = transform.position + new Vector3(0, y, x);
        transform.GetChild(1).transform.position = transform.position + new Vector3(0, -y, -x);
    }
}
