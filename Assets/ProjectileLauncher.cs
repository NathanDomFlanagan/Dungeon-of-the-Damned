using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public void fireProjectile()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = proj.transform.localScale;
        int val = 1;

        if (firePoint.position.x > 0)
        {
            val = 1;
        }
        if(firePoint.position.x < 0)
        {
            val = -1;
        }
        //Flips the projectile depending on the direction the user's facing.
        proj.transform.localScale = new Vector3(origScale.x * val, origScale.y, origScale.z);
    }
}
