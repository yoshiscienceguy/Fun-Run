using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    public float minY = -0.195f;
    public float maxY = 0.07f;
    public float speed = 1;
    public float triggerTime = 2;
    private float currentTime = 0;
    public float waitTime = 3;
    private bool goingUp;
    private bool goingDown;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime <= triggerTime)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            if (goingUp)
            {

                Vector3 to = new Vector3(0, maxY, 0);
                if (Vector3.Distance(transform.localPosition, to) > .01f)
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, to, speed * Time.deltaTime);
                }

            }
            else if (goingDown)
            {
                Vector3 to = new Vector3(0, minY, 0);
                if (Vector3.Distance(transform.localPosition, to) > .01f)
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, to, speed * Time.deltaTime);
                }

            }
            else
            {
                StartCoroutine(SpikeWait());
            }

        }


    }
    IEnumerator SpikeWait()
    {
        goingUp = true;
        goingDown = false;
        yield return new WaitForSeconds(waitTime);

        goingUp = false;
        goingDown = true;
        yield return new WaitForSeconds(waitTime);
        goingDown = false;
        goingUp = false;
        currentTime = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playermovement>().ReturntoPoint();
        }
    }
}
