using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameSound gameSound = GetComponent<GameSound>();
            if (gameSound != null)
            {
                gameSound.PlayPlayerInjureEnemySound();
            }
        }
    }
}
