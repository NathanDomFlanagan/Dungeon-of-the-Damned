using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    private Transform go;
    public bool pull;
    GameObject player = null;

    private void Awake()
    {
        go = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        try
        {
            player.GetComponent<PlayerController>().FindSpawn();
        }
        catch (System.Exception e)
        {

        }
            if (pull)
            {
                grabPlayer();
            }
        
    }
    public void grabPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = go.transform.localPosition;
    }
}
