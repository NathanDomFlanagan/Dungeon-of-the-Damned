using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour
{
    public AudioClip attackSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // or any other key you want to use for attack
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
}