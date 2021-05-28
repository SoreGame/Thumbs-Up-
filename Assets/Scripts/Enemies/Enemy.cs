using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private new SpriteRenderer renderer;
    private bool isHitted = false;
    private Color defaultColor;

    public float timeToColor;
    public int health = 100;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        defaultColor = renderer.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isHitted)
        {
            isHitted = true;
            StartCoroutine("SwitchColor");
        }
    }

    IEnumerator SwitchColor()
    {
        renderer.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(timeToColor);
        renderer.color = defaultColor;
        isHitted = false;
    }

}

