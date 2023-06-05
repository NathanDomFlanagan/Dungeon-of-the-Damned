using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("className"));
        Instantiate(Resources.Load(PlayerPrefs.GetString("className")),spawnPoint.position, spawnPoint.rotation);
        var targets = GameObject.FindGameObjectsWithTag("Player");

        CameraController camcon = camera.GetComponent<CameraController>();
        camcon.Find();
    }

}
