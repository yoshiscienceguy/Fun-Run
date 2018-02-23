using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    MeshRenderer mr;
    double bpm;
    double bpmInSec;
    double nextTime;
    bool glow = true;
    void Start() { 


        mr = GetComponent<MeshRenderer>();
        bpm = 100;
        bpmInSec = 60 / bpm;
        nextTime = AudioSettings.dspTime + bpmInSec;
    }
    private void Update()
    {
        if (AudioSettings.dspTime >= nextTime)
        {
            nextTime += bpmInSec;
            changeColor();
        }
    }

    void changeColor() {
        if (glow)
        {
            mr.material.SetColor("_EmissionColor", new Color(0, 1, 0.08965516f));
        }
        else {
            mr.material.SetColor("_EmissionColor", new Color(0, .5220588f, 0.04680527f));
        }
        glow = !glow;
        

    }
}
