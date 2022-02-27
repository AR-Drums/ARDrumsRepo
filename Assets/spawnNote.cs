using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNote : MonoBehaviour
{
    /*public Vector3 startPosition;
    public Vector3 endPosition;
    public float secondsOfLife;*/
    public GameObject noteObject;

    void Start() 
    {
        //Match speed with metronome
        InvokeRepeating("SpawnNote", 1.00f, 1.00f); //methodname, time in seconds, repeatRate seconds
            //SpawnNote();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {

            SpawnNote();
        
        }*/
    }

    void SpawnNote()
    {
      
        GameObject noteItem = Instantiate(noteObject, transform.position, transform.rotation);
        noteItem.transform.parent = gameObject.transform;
        noteItem.name = gameObject.name + "-note";
    }
}
