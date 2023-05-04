using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Damage")]
    public Animator animator;
    public Damageable dmg;
    
    [Header("Pathfinding")]
    public Transform target; //Target that the enemy targets (player)
    public float ActivateDistance = 50f; //Activation distance
    public float PathUpdateSecs = 0.5f; //How often A* updates
    

    [Header("Physics")]
    public float speed = 200f;
    public float NextWaypointDist = 3f; //How far away enemy has to be to travel to next waypoint
    public float JumpNodeHeightReq = 0.8f; //How vertical the next node has to be in order for the character to jump
    public float JumpModifier = 0.3f; //How high the jump is
    public float JumpCheckOffset = 0.1f; //Collider thing

    [Header("Custom Behaviour")] //For different enemy types
    public bool FollowEnabled = true;
    public bool JumpEnabled = true;
    public bool DirectionLookEnabled = true; //Checks if sprite needs to flip

    //Private variables
    private Path path;
    private int CurrWaypoint = 0;
    public DetectionZone attackZone;    //For attack
    public bool _hasTarget = false;
    bool IsGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;
    
    public bool HasTarget { 
        get { return _hasTarget; } 
        private set
        {
            _hasTarget = value;
            animator.SetBool("HasTarget",value);
        } 
    
    }

    // Start is called before the first frame update
    public void Start()
    {
        dmg = GetComponent<Damageable>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Knight_Prefab").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, PathUpdateSecs); //Repeats script every single path update secs
    }

    public void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
        if (!dmg.IsAlive)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if(TargetInDistance() && FollowEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (FollowEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        //Reached end of path
        if(CurrWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        //See if colliding with anything
        IsGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + JumpCheckOffset);

        //Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[CurrWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        //Jump
        if(JumpEnabled && IsGrounded)
        {
            if(direction.y > JumpNodeHeightReq)
            {
                rb.AddForce(Vector2.up * speed * JumpModifier);
            }
        }

        //Movement
        rb.AddForce(force);

        //Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[CurrWaypoint]);
        if(distance < NextWaypointDist)
        {
            CurrWaypoint++;
        }

        //Direction Graphics Handling
        if(DirectionLookEnabled)
        {
            if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if(rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < ActivateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            CurrWaypoint = 0;
        }
    }
   

    public void Die()
    {
        animator.SetBool("IsAlive", false);
        GetComponent<Collider2D>().enabled = false; //Disables enemy collision
        this.enabled = false; //Kills off the enemy
        Destroy(gameObject, 0);
    }
}
