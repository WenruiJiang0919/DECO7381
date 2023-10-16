using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {   
        //向量，坐标，旋转，缩放
        Vector3 v= new Vector3(1,1,1);
        v = Vector3.zero;
        v = Vector3.one;
        v = Vector3.left;
        v = Vector3.right;

        Vector3 v2 = Vector3.forward;

        //计算夹角
        Debug.Log(Vector3.Angle(v,v2));
        //计算两点间距离
        Debug.Log(Vector3.Distance(v,v2));
        //点乘
        Debug.Log(Vector3.Dot(v,v2));
        //叉乘
        Debug.Log(Vector3.Cross(v,v2));
        //插值
        Debug.Log(Vector3.Lerp(Vector3.zero, Vector3.one, 0.5f));
        //向量的模
        Debug.Log(v.magnitude);
        //规范化向量
        Debug.Log(v.normalized);
    }

   
}
