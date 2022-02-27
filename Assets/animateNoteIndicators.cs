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

    // Start is called before the first frame update
    void Start()
    {
     
        if (endPosition == new Vector3()) {
            endPosition = gameObject.transform.position;
            endPosition.x = GameObject.Find("End Point").transform.position.x;
    
        }

        if(startPosition == new Vector3())
        {
            startPosition = endPosition;
            startPosition.x = GameObject.Find("Start Point").transform.position.x;
        }

        if(secondsOfLife == 0)
        {
            //This might be a bug 
            //This is a cause of the notes spawning weirdness you mentioned
            //we need to match this with metronome 
            secondsOfLife = 2.5f;
        }

        speed = ((endPosition - startPosition) / secondsOfLife) * Time.deltaTime;
        
    }

    //For testing only
    void Update()
    {
        //New idea: toss out old means of tracking, and just have an item delete itself after it moves past a certain x; this only works for moving left, so alter as necessary
        if(transform.position.x > endPosition.x)
        {
            //noteList.Remove(item);
            Destroy(gameObject);
        }
        transform.Translate(speed);

    }


    public void MoveNotes()
    {

        var newNote = Instantiate(this.gameObject, transform.position, Quaternion.identity);
 
        //This also has to match with metrnome
        //The duration for each note on any tempo is exactly 0.50 seconds
        //http://www.moz.ac.at/sem/lehre/lib/cdp/cdpr5/html/timechart.htm#:~:text=This%20formula%20gives%20the%20duration,sec%20duration%20for%20each%20beat.
        iTween.MoveTo(newNote, iTween.Hash("x", 0f, "time", 0.5f, "delay", 0f, "easeType", iTween.EaseType.linear)); 
        Destroy(newNote, 0.5f); //the rate of destruction 
        //noteList.Add(newNote); 
    }

}

