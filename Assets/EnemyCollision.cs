using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameSound gameSound = collision.gameObject.GetComponent<GameSound>();
            if (gameSound != null)
            {
                gameSound.PlayEnemyInjurePlayerSound();
            }
        }
    }
}
