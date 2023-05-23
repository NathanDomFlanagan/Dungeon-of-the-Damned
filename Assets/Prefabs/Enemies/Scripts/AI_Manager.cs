using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Damageable))]

public class AI_Manager : MonoBehaviour
{
    [Header("Pathfinding")]
    [SerializeField]
    private float Movement;
    private Transform Target;
    private Rigidbody2D rb;
    private Vector3 Targetposition;
    private Collider2D col;
    public float minDistance = 4f;
    public bool constantFollow = false;     //Mainly used for wave spawner
    private float minConstFollow = 1f;

    [Header("Jump")]
    [SerializeField]
    private float JumpHeight;

    [Header("Damage")]
    public Animator animator;
    Damageable damageable;

    [Header("Attack Zone")]
    public DetectionZone attackZone;    //For attack
    public bool _hasTarget = false;

    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool("HasTarget", value);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  //Need this so that prefab clones can track the player
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = transform.parent.GetComponent<Animator>();
        col = transform.parent.GetComponent<Collider2D>();
    }

    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;

        Vector3 scale = transform.parent.localScale;
        if (Target.position.x > transform.parent.position.x)    //Player is on the right side of the enemy
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1;      //Swap the two equations for scale.x if enemy's sprite is created facing left

        }
        transform.parent.localScale = scale;
    }

    void FixedUpdate()
    {
        Targetposition = new Vector3(Target.position.x, rb.position.y, 0);
        if(!damageable.LockVelocity) //this if statement is for the knockback thing
        {
            if(constantFollow == true)
            {
                if (Vector2.Distance(transform.position, Target.position) > minConstFollow)
                {
                    rb.position = Vector2.MoveTowards(transform.position, Targetposition, Movement * Time.deltaTime);
                }
            } else
            {
                if (Vector2.Distance(transform.position, Target.position) < minDistance)
                {
                    rb.position = Vector2.MoveTowards(transform.position, Targetposition, Movement * Time.deltaTime);
                }
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, JumpHeight));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            Jump();
        }
    }

    public void OnHit(int dmg, bool trueDamage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
