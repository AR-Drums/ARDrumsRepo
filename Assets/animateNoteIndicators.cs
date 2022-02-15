//Reference: https://www.schoolofrock.com/resources/drums/drum-notation-for-beginners
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateNoteIndicators : MonoBehaviour
{
    public GameObject drumComponent; 
    //public GameObject[] drumComponent = new GameObject[2];

    //Vector3 targetPosition;
    //public string notation;
    //public float nextPlayTime;
    //public int currentNote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //For testing only
    void Update()
    {

        //Figure out how to spawn notes without keyboard press
        //Does successfully clone objects every key press but not I want 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveNotes();
            
        }
        //MoveNotes();
        
    }

    //For right now I used the iTween animation plugin from last semesters VR Drums Tutorial 
    //Not instantiating the prefabs correctly
    //Object can move on the X-Axis but only if it exists within the scene
    //I was trying to have the Note prefabs instantiate randomly so the player can play whatever rhythm spawns on the screen 
    public void MoveNotes()
    {

        //does not instantiate without this, causes bug if you repeatedly press key down
        //null pointer exception, drumComponent not assigned bug
        //GameObject tempNote = Instantiate(drumComponent, transform);
        //tempNote.transform.localPosition = new Vector3(5, 0, 0); 

        //Instantiating Notes but not in the correct position
        //Vector3 tempNote = new Vector3(0, 0, 0);

        Instantiate(this.gameObject, transform.position, Quaternion.identity);

        //Moves objects to the right on X axis 
        iTween.MoveTo(this.gameObject, iTween.Hash("x", 4.59, "time", 2f, "easeType", iTween.EaseType.linear, "local", true));
        Destroy(this.gameObject, 1.4f); //the rate of destruction 
    }

}

