using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    [Header("Drop Settings")]
    public GameObject[] itemsToDrop;   // Assign prefabs here
    public int minDrops = 1;
    public int maxDrops = 3;

    [Header("Spawn Radius")]
    public float dropRadius = 3f;

    [Header("Debug")]
    public bool dropOnStart = false; // for testing

    void Start()
    {
        if (dropOnStart)
        {
            DropLoot();
        }
    }

    // Call this when enemy dies
    public void DropLoot()
    {
        int dropCount = Random.Range(minDrops, maxDrops + 1);

        for (int i = 0; i < dropCount; i++)
        {
            if (itemsToDrop.Length == 0) return;

            GameObject item = itemsToDrop[Random.Range(0, itemsToDrop.Length)];

            // Random position in a circle around enemy
            Vector2 randomCircle = Random.insideUnitCircle * dropRadius;
            Vector3 spawnPos = transform.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

            Instantiate(item, spawnPos, Quaternion.identity);
        }
    }

    // Optional: visualize the drop radius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, dropRadius);
    }
}