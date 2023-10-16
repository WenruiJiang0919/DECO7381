using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debutg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        Debug.LogWarning("test2");
        Debug.LogError("test3");
    }

    // Update is called once per frame
    void Update()
    {
        //绘制一条线 起点，终点
        Debug.DrawLine(Vector3.left, Vector3.one, Color.blue);
        //绘制射线
        Debug.DrawRay(Vector3.zero, Vector3.up, Color.red);
    }
}
