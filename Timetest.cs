using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetest : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼ����ʱ��
        Debug.Log(Time.time);
        //ʱ������ֵ
        Debug.Log(Time.timeScale);
        //�̶�ʱ����
        Debug.Log(Time.fixedDeltaTime);
        //��һ֡����һ֡ʱ��
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
