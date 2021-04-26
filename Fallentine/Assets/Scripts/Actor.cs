using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioClip))]
public abstract class Actor : MonoBehaviour // this abstract class is inherited by all classes that use a Rigidbody2D and a collider.
{
    protected Rigidbody2D body; // the Actor's rigidbody
    protected Collider2D collider; // the Actor's collider
    protected AudioSource audio; // the Actor's audio
    public AudioClip clip; // the sound the Actor can play

    // Start is called before the first frame update
    protected virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        audio = GetComponent<AudioSource>();
       // clip = GetComponent<AudioClip>();
    }

    protected void PlaySound()
    {
        audio.PlayOneShot(clip, .5f);
    }
}
