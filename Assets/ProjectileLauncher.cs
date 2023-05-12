using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public void fireProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
    }
}
