using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField]
    private float Movement;
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    
    
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;
    private bool walkLeft;
    private float canTurn;
    private Vector3 scale;
    private Vector3 Targetposition;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = transform.parent.GetComponent<Animator>();
        col = transform.parent.GetComponent<Collider2D>();
        scale = transform.parent.localScale;
        walkLeft = true;
        canTurn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (walkLeft)    //Player is on the right side of the enemy
            {
                scale.x = Mathf.Abs(scale.x)*-1;
                Targetposition = new Vector3(pointB.position.x, rb.position.y, 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);      //Swap the two equations for scale.x if enemy's sprite is created facing left
                Targetposition = new Vector3(pointA.position.x, rb.position.y, 0);
            }
        if (Math.Abs(Targetposition.x - rb.position.x)<0.1)
        {
            walkLeft = !walkLeft;
        }
        /*
        else { }
        if (pointB.position.x < rb.position.x)
        {
            walkLeft = false;
        }*/
        rb.position = Vector2.MoveTowards(transform.position, Targetposition, Movement * Time.deltaTime);
        transform.parent.localScale = scale;
        UnityEngine.Debug.Log(walkLeft+""+ (pointA.position.x-rb.position.x));
    }

    void FixedUpdate()
    {
        if (walkLeft)
        {
            
        }
        else {
        
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            walkLeft = !walkLeft;

        
    }
    
}
