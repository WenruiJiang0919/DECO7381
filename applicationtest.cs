using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applicationtest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ�����ļ���·��
        Debug.Log(Application.dataPath + "/�½��ı��ĵ�.txt");
        //�־û��ļ���·��
        Debug.Log(Application.persistentDataPath);
        //StreamingAssets·��(ֻ�������ã�
        Debug.Log(Application.streamingAssetsPath);
        //��ʱ�ļ���
        Debug.Log(Application.temporaryCachePath);
        //�����Ƿ��ں�̨����
        Debug.Log(Application.runInBackground);
        //��url
        //Application.OpenURL("");
        //�˳���Ϸ
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
