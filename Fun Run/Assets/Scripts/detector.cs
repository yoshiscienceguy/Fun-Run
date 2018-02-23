using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour {
    double bpm;
    double bpmInSec;
    double nextTime;
    void Start()
    {
         bpm = 100;
         bpmInSec = 60 / bpm;
         nextTime = AudioSettings.dspTime + bpmInSec;
    }
    private void Update()
    {
        if (AudioSettings.dspTime >= nextTime) {
            Debug.Log("beat");
            nextTime += bpmInSec;
        }
    }
}
