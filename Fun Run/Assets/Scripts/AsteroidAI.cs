using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAI : MonoBehaviour {
    private float randomAngle;
    public float speed = 10f;
    public GameObject destoryedAsteriod;
    // Use this for initialization
    void Start () {
        randomAngle = Random.Range(-30, 30);
        transform.rotation = Quaternion.Euler(new Vector3(randomAngle, 0, 0));

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playermovement>().ReturntoPoint();
            GameObject cubes = Instantiate(destoryedAsteriod, transform.position, transform.rotation);
            Destroy(cubes, 3f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Base"))
        {
            GameObject cubes = Instantiate(destoryedAsteriod, transform.position, transform.rotation);
            Destroy(cubes, 3f);
            Destroy(gameObject);
        }
        
    }
}
