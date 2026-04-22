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
    public bool useYOverride = false;
    public float spawnYOverride = 0f;
    public float fallbackHeightOffset = 2f; // used if override is bad

    [Header("Debug")]
    public bool dropOnStart = false;
    public bool verboseDebug = true;

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

            Vector2 randomCircle = Random.insideUnitCircle * dropRadius;

            float finalY = transform.position.y;

            if (useYOverride)
            {
                // 🚑 Fix bad override values automatically
                if (Mathf.Approximately(spawnYOverride, 0f))
                {
                    finalY = transform.position.y + fallbackHeightOffset;

                    if (verboseDebug)
                    {
                        Debug.LogWarning(
                            $"[EnemyDropLoot] spawnYOverride was 0. Auto-correcting to {finalY}",
                            this
                        );
                    }
                }
                else
                {
                    finalY = spawnYOverride;
                }
            }

            Vector3 spawnPos = new Vector3(
                transform.position.x + randomCircle.x,
                finalY,
                transform.position.z + randomCircle.y
            );

            GameObject spawned = Instantiate(item, spawnPos, Quaternion.identity);

            // 🔒 Enforce Y after spawn
            if (useYOverride)
            {
                Vector3 p = spawned.transform.position;
                p.y = finalY;
                spawned.transform.position = p;
            }

            if (verboseDebug)
            {
                Debug.Log(
                    $"[DROP] '{spawned.name}' final Y={spawned.transform.position.y} " +
                    $"(override={useYOverride}, inputY={spawnYOverride})",
                    spawned
                );
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, dropRadius);
    }
}