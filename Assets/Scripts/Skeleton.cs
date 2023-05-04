using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Damage")]
    public Animator animator;
    private Rigidbody2D rd;
    public Transform target;

    //public Damageable dmg;

    [Header("Pathfinding")]
    //public Transform target; //Target that the enemy targets (player)
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
    //private Path path;
    private int CurrWaypoint = 0;
    public DetectionZone attackZone;    //For attack
    public bool _hasTarget = false;
    bool IsGrounded = false;
    //Seeker seeker;
    //Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (!target)
        {
            GetTarget();
        } else
        {
 
        }*/
    }/*
    private void GetTarget ()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGmeObjectWithTag("Player").transform;
        }
    }*/
}
