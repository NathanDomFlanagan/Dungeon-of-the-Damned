using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject inventoryMenu;
    private GameObject respawnMenu;

    public static bool isPaused = false;
    public InventoryManager iManager;

    // variables brought in and used for respawning
    private DeathManager dm;

    private bool disablePausing = false;

    void Awake() // Start is called before the first frame update    
    {
        pauseMenu = transform.GetChild(0).gameObject;
        inventoryMenu = transform.GetChild(1).gameObject;
        respawnMenu = transform.GetChild(2).gameObject;
        iManager = transform.parent.GetComponent<InventoryManager>();
        dm = transform.parent.GetComponent<DeathManager>();
        dm.SetMenuInteract(this);
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update() // Update is called once per frame
    {
        if (!disablePausing)
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

            if (Input.GetButtonDown("Inventory"))
            {
                if (isPaused)
                {
                    inventoryMenu.SetActive(false);
                    iManager.cleanInventory();
                    iManager.cleanEquip();
                    ResumeGame();
                }
                else
                {
                    GoToInventory();
                }
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
        iManager.SetActive(false);
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
        iManager.displayEquippedItems();
        iManager.SetActive(true);
    }
    
    public void GoToMainMenu()
    {
        Debug.Log("Going to main menu...");
        /*Time.timeScale = 1f;*/
        disablePausing = false;
        ResumeGame();
        GameObject p = GameObject.FindGameObjectsWithTag("Player")[0];
        PlayerModel pm = p.GetComponent<PlayerModel>();
        pm.DestroyThis();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void GoToRespawn()
    {
        disablePausing = true;
        respawnMenu.SetActive(true);
    }

    public void Respawn()
    {
        disablePausing = false;
        respawnMenu.SetActive(false);
        dm.Respawn();
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    
}
