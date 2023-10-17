//source：https://www.bilibili.com/video/BV1tB4y1J7ra/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=e81b410a72e94322b76cd65e6b58772b

using System.Collections.Generic;
using UnityEngine;

public class RTSManager : Singleton<RTSManager>
{
    public HashSet<RTSUtils> SelectedRtsUtilsSet = new HashSet<RTSUtils>();
    public List<RTSUtils> AvailbleRtsUtilsList = new List<RTSUtils>();

    // Start is called before the first frame update
    private void Start()
    {
        // You can perform any initialization logic here.
    }

    public void Selected(RTSUtils utils)
    {
        utils.OnSelected();
        SelectedRtsUtilsSet.Add(utils);
    }

    public void DeSelected(RTSUtils utils)
    {
        utils.OnDeSelected();
        SelectedRtsUtilsSet.Remove(utils);
    }

    public void DeSelectedAll()
    {
        foreach (var eachSet in SelectedRtsUtilsSet)
        {
            eachSet.OnDeSelected();
        }

        SelectedRtsUtilsSet.Clear();
    }

    public bool IsSelected(RTSUtils utils)
    {
        return SelectedRtsUtilsSet.Contains(utils);
    }
    public void HandleUtilsDestruction(RTSUtils utils)
    {
        if (AvailbleRtsUtilsList != null)
        {
            AvailbleRtsUtilsList.Remove(utils);
        }
        if (SelectedRtsUtilsSet != null)
        {
            SelectedRtsUtilsSet.Remove(utils);
        }
    }
}

