using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed = 20f;
    public int damage = 10;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        Destroy(gameObject, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyAI ai = collision.GetComponent<EnemyAI>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            ai.isTriggered = true;
        }

        Destroy(gameObject);
    }
}
