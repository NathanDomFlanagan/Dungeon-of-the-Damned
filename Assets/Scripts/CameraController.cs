using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private Transform rbTransform;

    // Start is called before the first frame update
    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rbTransform = player.transform;
        vcam.LookAt = rbTransform;
        vcam.Follow = rbTransform;
    }

    public void Find()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rbTransform = player.transform;
        vcam.LookAt = rbTransform;
        vcam.Follow = rbTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
