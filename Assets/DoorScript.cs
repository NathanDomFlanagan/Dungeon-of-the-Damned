using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private float timer = 60f;
    private bool isTimerActive = true;

    private void Update()
    {
        if (isTimerActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Deactivate the door object
                gameObject.SetActive(false);
                isTimerActive = false;
            }
        }
    }
    
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Lvl4")
        {
            isTimerActive = true;
        }
    }
}
