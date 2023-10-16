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
//source：https://www.bilibili.com/video/BV1tB4y1J7ra/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=e81b410a72e94322b76cd65e6b58772b
