using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public Vector2 moveSpeed = new Vector2(3f,0);   //Change 2nd option to add gravity (projectile motion)
    public int damage = 10;
    public Vector2 knockback = new Vector2(10f, 5f);

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable dmg = collision.GetComponent<Damageable>();

        if (dmg != null)
        {
            knockback.x = knockback.x * transform.localScale.x;
            collision.GetComponent<Damageable>().Hit(damage,true,knockback);
            Debug.Log("Projectile attack hit for " + damage);
            Destroy(gameObject);
        }
    }
}
