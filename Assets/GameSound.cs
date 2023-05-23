using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public AudioClip attackSound;
    public AudioClip jumpSound;
    public AudioClip playerInjureEnemySound;
    public AudioClip enemyInjurePlayerSound;
    public float attackDelay = 1.0f;
    public float attackVolume = 1.0f;
    public float jumpVolume = 1.0f;
    public float collisionVolume = 1.0f;
    private AudioSource audioSource;
    private bool canAttack = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canAttack)
        {
            StartCoroutine(PlayAttackSoundWithDelay());
        }

        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     audioSource.PlayOneShot(attackSound, attackVolume);
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpSound, jumpVolume);
        }
    }

    IEnumerator PlayAttackSoundWithDelay()
    {
        canAttack = false;
        audioSource.PlayOneShot(attackSound);
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound, attackVolume);
    }

    public void PlayPlayerInjureEnemySound()
    {
        audioSource.PlayOneShot(playerInjureEnemySound, collisionVolume);
    }

    public void PlayEnemyInjurePlayerSound()
    {
        audioSource.PlayOneShot(enemyInjurePlayerSound, collisionVolume);
    }
}