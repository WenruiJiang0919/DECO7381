using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RTSUtils : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        RTSManager.Instance.AvailbleRtsUtilsList.Add(this);

        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void DoMove(Vector3 pos) 
    {
       _agent.destination = pos;
    }

    public void OnSelected()
    {
        _spriteRenderer.gameObject.SetActive(true);
    }

    public void OnDeSelected()
    {
        _spriteRenderer.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        if (RTSManager.Instance != null)
        {
            RTSManager.Instance.HandleUtilsDestruction(this);
        }
    }
}
