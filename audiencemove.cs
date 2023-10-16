using UnityEngine;
using UnityEngine.AI;

public class MoveAfterDelay : MonoBehaviour
{
    public float delay = 10f; // 延迟时间
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Invoke("FindTargetAndMove", delay); // 在指定的延迟之后调用FindTargetAndMove方法
    }

    private void FindTargetAndMove()
    {
        // 根据标签"Door"查找建筑物
        GameObject door = GameObject.FindGameObjectWithTag("targetdoor1");

        if (door != null)
        {
            agent.SetDestination(door.transform.position);
        }
    }
}