using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{

    [Header("Attack Zone")]
    public DetectionZone attackZone;    //For attack
    public Animator animator;
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
        attackZone = GetComponent<DetectionZone>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
    }
}
