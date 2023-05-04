using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;
    EnemyAI enemy;

    [SerializeField]
    private float _maxHealth = 100;

    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private float _Health = 100;

    [SerializeField]
    private bool isInvincible = false;
    private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;

    public float Health
    {
        get
        {
            return _Health;
        }
        set
        {
            _Health = value;

            //If health drops below 0, character is dead
            if(_Health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive = true;

    public bool IsAlive
    {
        get 
        { 
            return _isAlive; 
        }
        set 
        { 
            _isAlive = value; 
            animator.SetBool("IsAlive",value);
            Debug.Log("IsAlive set " + value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isInvincible)
        {
            if(timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
        //Hit(10); //Testing to see if it works
    }

    public bool Hit(int dmg)
    {
        if(IsAlive && !isInvincible)
        {
            animator.SetTrigger("Hurt");
            Health -= dmg;
            isInvincible = true;
            return true;
        }
        return false;
    }
}

