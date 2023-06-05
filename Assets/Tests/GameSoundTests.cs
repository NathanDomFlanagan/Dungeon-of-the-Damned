using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameSoundTests
{
    [Test]
    public void PlayAttackSound_AttackSoundPlayed()
    {
        // Arrange
        var gameSound = new GameObject().AddComponent<GameSound>();
        var audioSource = gameSound.gameObject.AddComponent<AudioSource>();
        audioSource.clip = gameSound.attackSound;

        // Act
        gameSound.PlayAttackSound();

        // Assert
        Assert.IsTrue(audioSource.isPlaying);
    }
}
