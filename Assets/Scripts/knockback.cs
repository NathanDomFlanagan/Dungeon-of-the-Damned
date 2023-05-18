using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class knockback : MonoBehaviour
{
 [SerializeField] private float thrust;

 private void OnTriggerEnter2D(Collider2D collision)
 {
    if (collision.gameObject.CompareTag("Enemy"))
    {
        Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
        if (enemy != null)
        {
            StartCoroutine(KnockCoroutine(enemy));
        }
    }
 }

 private IEnumerator KnockCoroutine(Rigidbody2D enemy)
 {
    Vector2 forceDirection = enemy.transform.position - transform.position;
    Vector2 force = forceDirection.normalized * thrust;

    enemy.velocity = force;
    yield return new WaitForSeconds(.3f);

    enemy.velocity = new Vector2();
 }
}
