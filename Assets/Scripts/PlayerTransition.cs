using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    private Transform go;
    public bool pull;

    private void Awake()
    {
        go = this.transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().FindSpawn();

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
