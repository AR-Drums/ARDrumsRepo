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
    }
}
