using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public CinemachineVirtualCameraBase camera;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("className"));
        Instantiate(Resources.Load(PlayerPrefs.GetString("className")),spawnPoint.position, spawnPoint.rotation);
        var targets = GameObject.FindGameObjectsWithTag("Player");
        if(targets.Length > 0)
        {
            camera.LookAt = camera.Follow = targets[0].transform;
        }

    }

}
