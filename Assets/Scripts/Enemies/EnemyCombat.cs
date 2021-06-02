using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private Animator animator;
    private EnemyAI enemyEntity;
    public Transform attackPoint;
    public LayerMask playerLayer;
    
    private float nextAttackTime = 0f;
    public float attackRange = 0.5f;
    public int attackDamage = 5;
    public float attackRate = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyEntity = gameObject.GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {        
            if (enemyEntity.isInAttackRadius)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
            else
            {
                if (!enemyEntity.isInChaseRadius && !enemyEntity.isTriggered)
                {
                    enemyEntity.animator.SetBool("isWalking", false);
                }
            }
        }
    }

    private void Attack()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);       
        animator.SetTrigger("Attack");
        if (hitPlayer != null && hitPlayer.gameObject.activeInHierarchy == true)
        {
            hitPlayer.GetComponent<Player>().TakeDamage(attackDamage);
            hitPlayer.GetComponent<Player>().StartCoroutine("SwitchColor");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
