using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{

    private Vector3 lastPosition;
    public Vector3 heading;
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        heading = transform.position - lastPosition;
        lastPosition = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        //Checks to see that the collider only reacts when ball goes through the vector head itself
        //Should not react when the ball misses the drum header
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
      