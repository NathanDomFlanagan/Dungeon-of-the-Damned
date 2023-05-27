using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPaused = false;

    void Start() // Start is called before the first frame update    
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update() // Update is called once per frame
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when clicking the escape key
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Set the time scale to 1 to play the game
        isPaused = false;
    }

public void GoToSetting()
    {
        Debug.Log("Going to setting menu...");
        /*Time.timeScale = 1f; //Set the time scale to 1, so that it won't pause in the setting menu
        SceneManager.LoadScene("SettingMenu");
        isPaused = false;*/
    }

public void GoToInventory()
    {
        Debug.Log("Going to inventory...");
        /*Time.timeScale = 1f;
        SceneManager.LoadScene("Inventory");
        isPaused = false;*/
    }
    
    public void GoToMainMenu()
    {
        Debug.Log("Going to main menu...");
        /*Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;*/
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    
}
