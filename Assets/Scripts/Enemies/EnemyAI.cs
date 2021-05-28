using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float chaseRadius;
    public float attackRadius;
    public LayerMask whatIsPlayer;
    public bool lookRight = true;

    private Transform target;
    private Rigidbody2D rb2D;
    internal Animator animator;
    private Vector3 direction;
    private Vector2 movement;
    internal bool isTriggered;  
    internal bool isInChaseRadius;
    internal bool isInAttackRadius;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        isInChaseRadius = Physics2D.OverlapCircle(transform.position, chaseRadius, whatIsPlayer);
        isInAttackRadius = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        if (target != null)
        {
            direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
        
        if (!lookRight && movement.x > 0)
        {
            Flip();
        }
        
        if (lookRight && movement.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if ((isInChaseRadius && !isInAttackRadius) || (isTriggered && !isInAttackRadius))
        {
            animator.SetBool("isWalking", true);
            MoveCharacter(movement);
        }      

        if (isInAttackRadius)
        {
            animator.SetBool("isWalking", false);
            rb2D.velocity = Vector2.zero;
        } 
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
