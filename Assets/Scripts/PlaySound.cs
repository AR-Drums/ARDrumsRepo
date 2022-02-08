using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    private AudioSource source;
    public float pitch_input;

	// Use this for initialization
	void Start ()
    {
        source = transform.parent.gameObject.GetComponent<AudioSource>();
	}

    private void OnMouseDown()
    {
        ActivateSound();
    }

    private void ActivateSound()
    {
        source.pitch = pitch_input;
        source.Play();
    }

}
