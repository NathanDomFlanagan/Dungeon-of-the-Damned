using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //References
    private bool isAttacking;
    private bool trueDamage;
    private bool canAttack = true;
    private Damageable dmg;

    private Animator anim;

    private float attackTimer = 0.0f;
    public bool IsArcher = false;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;


    //Damage amount
    private int AtkDmg = 50;
    private Vector2 knockbackforce = new Vector2(10f,5f);

    //Attack Time
    private float AtkRate = 4.0f;
    // Start is called before the first frame update
    void Awake()
    { 
        anim = GetComponent<Animator>();
        dmg = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
        CheckAttack();
        if(!dmg.IsAlive)
        {
            AtkDmg = 0;
            AtkRate = 0f;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("canAttack", canAttack);
    }

    public void SetStats(int dmg, float attackRate, float attackRange, bool truedamage)
    {
        AtkDmg = dmg;
        AtkRate = attackRate;
        AttackRange = attackRange;
        trueDamage = truedamage;
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
                Vector2 knockback = getKnockBack(enemy);
                enemy.GetComponent<Damageable>().Hit(AtkDmg,trueDamage,knockback);
            UnityEngine.Debug.Log("Damage");
            }
    }

    Vector2 getKnockBack(Collider2D enemy)
    {
        if ((enemy.transform.position.x - transform.position.x) < 0)
        {
            return new Vector2(-knockbackforce.x, knockbackforce.y);
        }
        else {
            return new Vector2(knockbackforce.x, knockbackforce.y);   
        }
            
    }


void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
 