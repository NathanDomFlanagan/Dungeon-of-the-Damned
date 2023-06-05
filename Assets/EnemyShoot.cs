using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Animator animator;
    public float shootTime;
    public float timeTillShoot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeTillShoot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillShoot <= 0f)
        {
            animator.SetTrigger("Attack");
            timeTillShoot = shootTime;
        }
        timeTillShoot -= Time.deltaTime;
    }
}
