using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private PlayerController pc;
    private Damageable dmg;

    // Update is called once per frame

    public void SetPC(PlayerController playercontroller)
    {
        pc = playercontroller;
    }

    public void SetDamagable(Damageable damagable)
    {
        dmg = damagable;
    }
    
    //needs to create a new inventory to override what was existing before.


    void Update()
    {
        if (!dmg.IsAlive)
        {
            dmg.Respawn();
            pc.isEnter = true;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }   
    }
}
