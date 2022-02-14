using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    private static Metronome instance;
    public static Metronome Instance 
    { 
        get 
        { 
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(Metronome)) as Metronome;
            }
            
            return instance; 
        } 
    }

    private bool ticking = false;

    void Start()
    {
        StartCoroutine(Ticker());
    }

    private IEnumerator Ticker()
    {
        ticking = true;
        while (ticking)
        {
            Debug.Log("Tick");
            yield return new WaitForSeconds(1);
        }
    }
}
