using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            
        }
    }
}
