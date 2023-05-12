using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public void fireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = transform.localScale;

        //Flips the projectile depending on the direction the user's facing.
        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z
            );
    }
}
