using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    private float maxHealth;

    public float foodHealing = 1f;

    public Image healthBar;

    private void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;

        Debug.Log("Player initialized with health: " + health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy. Taking damage.");
            TakeDamage(1f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Food"))
        {
            float oldHealth = health;

            health += foodHealing;

            if (health > maxHealth)
            {
                health = maxHealth;
            }

            healthBar.fillAmount = health / maxHealth;

            Debug.Log("Picked up food. Healed from " + oldHealth + " to " + health);

            Destroy(collider.gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        float oldHealth = health;

        health -= amount;

        healthBar.fillAmount = health / maxHealth;

        Debug.Log("Took damage: " + amount + ". Health: " + oldHealth + " -> " + health);

        if (health <= 0)
        {
            Debug.Log("Player died. Reloading scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
    }
}