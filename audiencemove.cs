using UnityEngine;
using UnityEngine.AI;

public class MoveAfterDelay : MonoBehaviour
{
    public float delay = 10f; // delay time
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Invoke("FindTargetAndMove", delay); // Call the FindTargetAndMove method after the specified delay.
    }

    private void FindTargetAndMove()
    {
        // Find buildings according to the label "Door".
        GameObject door = GameObject.FindGameObjectWithTag("targetdoor1");

        if (door != null)
        {
            agent.SetDestination(door.transform.position);
        }
    }
}
