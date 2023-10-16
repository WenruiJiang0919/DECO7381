using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetest : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //游戏开始至今时间
        Debug.Log(Time.time);
        //时间缩放值
        Debug.Log(Time.timeScale);
        //固定时间间隔
        Debug.Log(Time.fixedDeltaTime);
        //上一帧到这一帧时间
        Debug.Log(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        /*if (timer == 10)
        {
            Debug.Log("10s");
        }*/
    }
}
