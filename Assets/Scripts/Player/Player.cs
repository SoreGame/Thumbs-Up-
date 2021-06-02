using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new SpriteRenderer renderer;
    private bool isHitted = false;
    private Color defaultColor;
    internal int currentHealth = 100;

    public HealthBar healthBar;
    public int maxHealth;
    public float timeToColor;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        renderer = GetComponent<SpriteRenderer>();
        defaultColor = renderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        LevelManager.instance.Respawn();
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHitted && gameObject.activeInHierarchy == true
            && other.CompareTag("Enemy"))
        {
            isHitted = true;
            StartCoroutine("SwitchColor");
        }
    }

    IEnumerator SwitchColor()
    {
        if (gameObject.activeInHierarchy == true)
        {
            renderer.color = new Color(1f, 0.30196078f, 0.30196078f);
            yield return new WaitForSeconds(timeToColor);
            renderer.color = defaultColor;
            isHitted = false;
        }
    }
}
