using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject inventoryMenu;

    public static bool isPaused = false;
    public InventoryManager iManager;

    void Awake() // Start is called before the first frame update    
    {
        iManager = transform.parent.GetComponent<InventoryManager>();
        pauseMenu = transform.GetChild(0).gameObject;
        inventoryMenu = transform.GetChild(1).gameObject;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update() // Update is called once per frame
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when clicking the escape key
        {
            if (isPaused)
            {
                inventoryMenu.SetActive(false);
                iManager.cleanInventory();
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if(Input.GetButtonDown("Inventory"))
        {
            if(isPaused)
            { 
                inventoryMenu.SetActive(false);
                iManager.cleanInventory();
                ResumeGame();
            } else
            {
                GoToInventory();
            }
        }
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        isPaused = true;
    }

    private void ResumeGame()
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
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Going to inventory...");
        pauseMenu.SetActive(false);
        inventoryMenu.SetActive(true);
        iManager.ListItems();
  
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
