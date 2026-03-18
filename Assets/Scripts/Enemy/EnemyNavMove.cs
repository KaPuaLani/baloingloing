using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [Header("Distances")]
    public float chaseStartDistance = 10f; // aggro range
    public float chaseStopDistance = 20f;  // de-aggro range

    private Vector3 home;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        home = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Start chasing
        if (!isChasing && distance <= chaseStartDistance)
        {
            isChasing = true;
            Debug.Log("Enemy: Player detected, starting chase!");
        }

        // Stop chasing
        if (isChasing && distance >= chaseStopDistance)
        {
            isChasing = false;
            Debug.Log("Enemy: Player escaped, returning home.");
        }

        // Apply movement
        if (isChasing)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = home;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Start chase range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseStartDistance);

        // Stop chase range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseStopDistance);

        // Home position
        Gizmos.color = Color.green;
        Vector3 drawHome = Application.isPlaying ? home : transform.position;
        Gizmos.DrawSphere(drawHome, 0.3f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, drawHome);
    }
}