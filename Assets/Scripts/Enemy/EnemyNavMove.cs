using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 10;
    private Vector3 home;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        home = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.transform.position - transform.position;

        if (direction.magnitude < chaseDistance)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = home;
        }
    }

    // Gizmos for visualization
    void OnDrawGizmosSelected()
    {
        // Draw chase range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        // Draw home position
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(home, 0.3f);

        // Draw line to home
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, home);
    }
}