using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject doorObject;
    public string enemyTag = "Enemy";

    private int enemyCount;

    private void Start()
    {
        // Find all game objects with the enemy tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        enemyCount = enemies.Length;
    }

    private void Update()
    {
        if (AreAllEnemiesDefeated())
        {
            OpenDoor();
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Check if any enemies are still active
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                return false; // At least one enemy is still active
            }
        }

        return true; // All enemies are defeated
    }

    private void OpenDoor()
    {
        // Open the door by disabling its collider or animation, etc.
        doorObject.SetActive(false);
    }
}
