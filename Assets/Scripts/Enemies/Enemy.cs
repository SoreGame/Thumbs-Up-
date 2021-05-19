using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly int maxHealth = 100;
    private int currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play take damage animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play death animation
        Destroy(gameObject);
    }
}

