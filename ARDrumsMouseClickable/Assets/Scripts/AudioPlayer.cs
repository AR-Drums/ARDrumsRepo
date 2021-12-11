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

    private void OnMouseDown()
    {
        source.Play();
    }
}
