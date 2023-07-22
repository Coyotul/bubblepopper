using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSong : MonoBehaviour
{
    public AudioClip menuMusic; // The menu music (mp3, wav, or any audio format supported by Unity)
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();

        // Set the menu music for the AudioSource
        audioSource.clip = menuMusic;

        // Loop the menu music (it will play continuously)
        audioSource.loop = true;

        // Start playing the menu music
        audioSource.Play();
    }
}