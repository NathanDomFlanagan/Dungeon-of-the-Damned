using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private PlayerController pc;
    private Damageable dmg;
    private PauseMenu pause;
    private bool tryRespawning = true;

    // Update is called once per frame

    public void SetPC(PlayerController playercontroller)
    {
        pc = playercontroller;
    }

    public void SetDamagable(Damageable damagable)
    {
        dmg = damagable;
    }


    public void SetMenuInteract(PauseMenu pauseMenu)
    {
        pause = pauseMenu;
    }
    //needs to create a new inventory to override what was existing before.


    public void Respawn()
    {
        dmg.Respawn();
        pc.isEnter = true;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void Update()
    {
        if (!dmg.IsAlive && tryRespawning)
        {
            tryRespawning = false;
            pause.GoToRespawn();
        }
    }
}
