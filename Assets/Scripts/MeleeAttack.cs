using UnityEngine.InputSystem;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Melee Settings")]
    public int range = 2;           // Attack range (now int)
    public int damage = 25;         // Damage dealt (int)
    public LayerMask hitLayers;

    [Header("Attack Origin")]
    public Transform attackPoint;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Physics still expects a float for radius, so we convert here
        Collider[] hits = Physics.OverlapSphere(attackPoint.position, (float)range, hitLayers);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyHealth enemy = hit.GetComponent<EnemyHealth>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage); // now matches int
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, (float)range);
    }
}