//Reference: https://www.schoolofrock.com/resources/drums/drum-notation-for-beginners
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateNoteIndicators : MonoBehaviour
{
    //public GameObject drumComponent;
    public Vector3 endPosition;
    public float secondsOfLife;
    public ArrayList noteList;
    public Vector3 startPosition;
    private Vector3 speed;
    //public GameObject[] drumComponent = new GameObject[2];

    //Vector3 targetPosition;
    //public string notation;
    //public float nextPlayTime;
    //public int currentNote;

    // Start is called before the first frame update
    void Start()
    {
        //noteList = new ArrayList();
        if (endPosition == new Vector3()) {
            endPosition = gameObject.transform.position;
            endPosition.x = GameObject.Find("End Point").transform.position.x;
            //endPosition = GameObject.Find("End Point").transform.position; 
        }

        if(startPosition == new Vector3())
        {
            startPosition = endPosition;
            startPosition.x = GameObject.Find("Start Point").transform.position.x;
        }

        if(secondsOfLife == 0)
        {
            secondsOfLife = 1.4f;
        }

        speed = ((endPosition - startPosition) / secondsOfLife) * Time.deltaTime;
    }

    //For testing only
    void Update()
    {

        //Figure out how to spawn notes without keyboard press
        //Does successfully clone objects every key press but not I want 
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //MoveNotes();
        //    SpawnNote();
        //}

        //ClearDeadNotes();
        //foreach(GameObject item in noteList)
        //{

        //New idea: toss out old means of tracking, and just have an item delete itself after it moves past a certain x; this only works for moving left, so alter as necessary
        if(transform.position.x > endPosition.x)
        {
            //noteList.Remove(item);
            Destroy(gameObject);
        }
        transform.Translate(speed);
        //}

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

        var newNote = Instantiate(this.gameObject, transform.position, Quaternion.identity);

        //Moves objects to the right on X axis 
        iTween.MoveTo(newNote, iTween.Hash("x", 1.0, "time", 1.0f, "easeType", iTween.EaseType.linear, "local", true));
        Destroy(newNote, 2.0f); //the rate of destruction 
        noteList.Add(newNote);
    }

}

