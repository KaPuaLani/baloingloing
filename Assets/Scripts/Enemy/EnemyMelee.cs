using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

    [Header("Target")]
    public Transform player;

    [Header("Optional")]
    public Animator animator;
    public string attackTriggerName = "Attack";

    private float lastAttackTime;
    private bool wasInRange = false;

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("EnemyMelee: No player assigned!");
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        // Log entering/exiting range
        if (distance <= attackRange && !wasInRange)
        {
            Debug.Log("Enemy entered attack range.");
            wasInRange = true;
        }
        else if (distance > attackRange && wasInRange)
        {
            Debug.Log("Enemy left attack range.");
            wasInRange = false;
        }

        if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("Enemy attacking!");
            Attack();
        }
    }

    void Attack()
    {
        lastAttackTime = Time.time;

        if (animator != null && !string.IsNullOrEmpty(attackTriggerName))
        {
            animator.SetTrigger(attackTriggerName);
            Debug.Log("Attack animation triggered.");
        }

        DealDamage();
    }

    void DealDamage()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(attackDamage);
                Debug.Log("Enemy dealt " + attackDamage + " damage to player.");
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found on player!");
            }
        }
        else
        {
            Debug.Log("Attack missed (player out of range at hit moment).");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}