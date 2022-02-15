using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class onCollision : MonoBehaviour
{

    public GameObject visualIndicatorObject; //An attached object for testing purposes to represent
    //whether we passed through the top or bottom
    //public bool hasTriggered = false;
    private Transform visualIndicatorTransform;
    public Vector3 drumHeading; //Public for testing purposes
    Vector3 stickHeading;
    public Vector3 relativeHeading; //Public for testing purposes

    public AudioClip impact;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        visualIndicatorTransform = visualIndicatorObject.GetComponent<Transform>();
        //AudioSource.PlayClipAtPoint(snare, new Vector3(0, 1, 0));

        //impact = Resources.Load("Audio/Snare") as AudioClip;
        //impact = Resources.Load<AudioClip>("Audio/Snare");
        //source = gameObject.AddComponent<AudioSource>();

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        float audio = collision.relativeVelocity.magnitude / 10.0f;
        source.PlayOneShot(impact, audio);
    }*/


    private void OnTriggerEnter(Collider other)
    {

        //Figure out which direction the drum head is facing, in heading vectors
        drumHeading = transform.forward;

        //If it's forward == 0,0,1, then errors will be thrown; replace the drum heading with facedown
        //for some reason, because that somehow works. 
        if(drumHeading == Vector3.forward)
        {
            drumHeading = -transform.up;
        }

        //Other is the collider detected above; the drum stick should have a rigidbody attached to it, 
        //and should have a script attached to it with a public Vector3; moveBall is this
        //script's name, and here are the script contents: 
        /*
         * private Vector3 lastPosition;
         * public Vector3 heading;
         * 
         * void Start()
            {
                lastPosition = transform.position;
            }
            
            private void FixedUpdate()
            {
                heading = transform.position - lastPosition;
                lastPosition = transform.position;
            }
         */
        stickHeading = other.gameObject.GetComponent<moveBall>().heading;

        //Figure out the magnitude 1 heading vector of the stick relative to the drum collider
        relativeHeading = Vector3.Project(stickHeading, drumHeading);
        if(Vector3.Magnitude(relativeHeading) > 0) //Preventing a divide by 0 error
        {
            relativeHeading = relativeHeading / Mathf.Abs(Vector3.Magnitude(relativeHeading));
        }
        
        //Little extra math, not sure why it's necessary, but Unity screws up without it: 
        //Get what angle the collider's face is relative to straight up, so you can figure 
        //Out if the head is facing downward; if so, you need to reverse the relative heading's
        //direction; I'm guessing something about the magnitude work gets rid of the negative? 
        //Note: no memory allocation of a variable is needed; the angle variable is just here 
        //for easy viewing

        float angle = Vector3.Angle(transform.up, Vector3.up);
        if(angle > 90)
        {
            relativeHeading = relativeHeading * -1;
        }

        //This is needed to trigger the drum heading collider. Without this conditional no drum header collider exists. 
        if(relativeHeading == drumHeading)
        {
            //The case where you pass through the top of the drum collider
            visualIndicatorTransform.position = Vector3.up * 5;
        }
        else if (relativeHeading == -drumHeading)
        {
            //The case where you pass through the bottom of the drum collider
            visualIndicatorTransform.position = Vector3.down * 5;
        }
        else
        {
            //Catch all error case, because sometimes weird things happen
            visualIndicatorTransform.position = new Vector3(0, 0, 0);
        }
       
    }

   
}


