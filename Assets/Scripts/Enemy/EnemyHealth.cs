using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public Image healthBar;
    float maxHealth;

    [Header("Loot Settings")]
    public float lootSpawnY = 0f; // <-- NEW: public Y position

    private EnemyDropLoot dropLoot;

    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;

        dropLoot = GetComponent<EnemyDropLoot>();

        if (dropLoot == null)
        {
            Debug.LogWarning($"[EnemyHealth] No EnemyDropLoot found on {gameObject.name}");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"[EnemyHealth] {gameObject.name} died");

        if (dropLoot != null)
        {
            // Pass Y override before dropping
            dropLoot.spawnYOverride = lootSpawnY;
            dropLoot.useYOverride = true;

            dropLoot.DropLoot();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}