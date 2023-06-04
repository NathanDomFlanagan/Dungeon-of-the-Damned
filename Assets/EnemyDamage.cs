using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public AudioClip hurtSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Assuming the player has the "Player" tag
        {
            // Play the hurt sound
            audioSource.PlayOneShot(hurtSound);
        }
    }
}