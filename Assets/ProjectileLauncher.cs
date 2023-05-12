using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public void fireProjectile()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = proj.transform.localScale;
        
        proj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
    }
}
