using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explode : MonoBehaviour
{

    //public Damageable dmg;
    public Rigidbody2D rb;
    public LayerMask damageLayer;
    public LayerMask knockbackLayer;
    public Transform Atkpoint;
    public Vector2 knockbackforce = new Vector2(1f, 5f); 
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
    }

    void explode()
    {
        Collider2D[] HitTargets = Physics2D.OverlapCircleAll(Atkpoint.position, 5, damageLayer);

        //Damage target
        foreach (Collider2D target in HitTargets)
        {
            Vector2 knockback = getKnockBack(target);
            target.GetComponent<Damageable>().Hit(damage, true, knockback);
            UnityEngine.Debug.Log("Damage");
        }
        
    }
    
    Vector2 getKnockBack(Collider2D target)
    {
        if ((target.transform.position.x - transform.position.x) < 0)
        {
            return new Vector2(-knockbackforce.x, knockbackforce.y);
        }
        else
        {
            return new Vector2(knockbackforce.x, knockbackforce.y);
        }

    }
}
