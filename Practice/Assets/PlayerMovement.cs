using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References
    public CharacterController2D controller;
    public Animator animator;

    //Horizontal movement
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    //Vertical movement
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Left is -1 Right is +1
        //Debug.Log(Input.GetAxisRaw("Vertical")); //Up is +1 Down is -1

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove,false,jump);
        jump = false;
    }

    void Attack()
    {

    }
}
