using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public Player player;
    public int amountToIncrease = 30;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerHealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayer(collision))
        {
            if (isFullHealth(player))
            {
                
            }

            else if (player.currentHealth + amountToIncrease >= player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
                playerHealthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }

            else
            {
                player.currentHealth += amountToIncrease;
                playerHealthBar.SetHealth(player.currentHealth);
                Destroy(gameObject);
            }
        }
    }

    private bool isFullHealth(Player player) => (player.currentHealth == player.maxHealth);
    private bool isPlayer(Collider2D collision) => (collision.CompareTag("Player") && !collision.isTrigger);
}
