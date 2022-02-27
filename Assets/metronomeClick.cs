//Metrnome added for reference to make sure note spawning syncs with beats per minute
//Delete this later or modify with appropiate sound file
//Future Goal: sync note spawn with metronome BPM click
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metronomeClick : MonoBehaviour
{
    public double BPM = 140.0f;
    double nextTick = 0.0f;
    double sampleRate = 0.0f;
    bool ticks = false;

    // Start is called before the first frame update
    void Start()
    {
        double currentTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = currentTick + (60.0/BPM);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (!ticks && nextTick >= AudioSettings.dspTime) 
        {
            ticks = true;
            BroadcastMessage("OnTick");
        }
    }

    void OnTick()
    {
        
        GetComponent<AudioSource>().Play();
    
    }

    void FixedUpdate() 
    {
        double ratePerTick = 60.0f / BPM;
        double dspTime = AudioSettings.dspTime;

        while (dspTime >= nextTick)
        {
            ticks = false;
            nextTick += ratePerTick;
        }
    }
}
