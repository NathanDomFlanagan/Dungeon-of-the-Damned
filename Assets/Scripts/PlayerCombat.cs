using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //References
    private bool isAttacking;
    private bool canAttack = true;

    private Animator anim;

    public float attackTimer = 0.0f;

    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;


    //Damage amount
    public int AtkDmg = 50;

    //Attack Time
    public float AtkRate = 4.0f;
    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
        CheckAttack();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("canAttack", canAttack);
    }

    public void SetStats(int dmg, float attackRate, float attackRange)
    {
        AtkDmg = dmg;
        AtkRate = attackRate;
        AttackRange = attackRange;
    }

    void CheckAttack()
    {
        if (attackTimer <= 0.0f)
        {
            if (isAttacking)
            {
                isAttacking = false;
            }
            if (!canAttack)
            {
                canAttack = true;
            }
        }else
        {
            if(canAttack)
            {
                canAttack = false;
            }
            attackTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Attack") && canAttack)
        {
            attackTimer = 1.0f / AtkRate;
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;

        //Detect enimies in range of attack
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        //Damage enemy
        foreach (Collider2D enemy in HitEnemies)
        {
            enemy.GetComponent<Damageable>().Hit(AtkDmg);
            Debug.Log("Damage");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
 