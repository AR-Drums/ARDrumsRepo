using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    /*private void OnMouseDown()
    {
        source.Play();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //stickPosition = other.transform.position;
        source.pitch = Random.Range(0.8f, 1.2f);
        source.volume = other.gameObject.GetComponent<moveBall>().heading.magnitude * 10;
        source.Play();
    }
}
