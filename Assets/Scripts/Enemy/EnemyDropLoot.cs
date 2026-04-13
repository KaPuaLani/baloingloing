using UnityEngine;

public class EnemyDropLoot : MonoBehaviour
{
    [Header("Drop Settings")]
    public GameObject[] itemsToDrop;
    public int minDrops = 1;
    public int maxDrops = 3;

    [Header("Spawn Radius")]
    public float dropRadius = 3f;

    [Header("Y Spawn Control")]
    public bool useYOverride = false;     // enable override
    public float spawnYOverride = 0f;     // target Y value

    [Header("Debug")]
    public bool dropOnStart = false;

    void Start()
    {
        if (dropOnStart)
        {
            DropLoot();
        }
    }

    public void DropLoot()
    {
        if (itemsToDrop == null || itemsToDrop.Length == 0)
        {
            Debug.LogWarning($"[EnemyDropLoot] No items assigned on {gameObject.name}");
            return;
        }

        if (minDrops > maxDrops)
        {
            Debug.LogError($"[EnemyDropLoot] Invalid drop range on {gameObject.name}");
            return;
        }

        int dropCount = Random.Range(minDrops, maxDrops + 1);

        for (int i = 0; i < dropCount; i++)
        {
            GameObject item = itemsToDrop[Random.Range(0, itemsToDrop.Length)];
            if (item == null) continue;

            // Base random position
            Vector2 randomCircle = Random.insideUnitCircle * dropRadius;
            Vector3 spawnPos = transform.position + new Vector3(randomCircle.x, 0f, randomCircle.y);

            // Apply Y override if enabled
            if (useYOverride)
            {
                spawnPos.y = spawnYOverride;
            }

            Instantiate(item, spawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, dropRadius);
    }
}