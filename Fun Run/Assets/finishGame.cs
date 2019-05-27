using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<playermovement>().enabled = false;
            other.gameObject.GetComponentInChildren<AnimationRotation>().enabled = false;
            other.gameObject.GetComponentInChildren<Animator>().SetFloat("speed",0);
            other.gameObject.GetComponentInChildren<Animator>().SetTrigger("Done");
            Player.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 90, 0);
            winScreen.SetActive(true);
        }
    }
    public void RestartGame() {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}

