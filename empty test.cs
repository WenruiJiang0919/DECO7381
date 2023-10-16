using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptytest : MonoBehaviour
{
    public GameObject Cube;
    //获取预设体
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = gameObject;
        Debug.Log(gameObject.name);
        //tag
        Debug.Log(gameObject.tag);
        //图层
        Debug.Log(gameObject.layer);
        Debug.Log(Cube.name);
        //实际激活状态
        Debug.Log(Cube.activeInHierarchy);
        //自身激活状态
        Debug.Log(Cube.activeSelf);
        //获取Transform
        Debug.Log(transform.position);
        Debug.Log(transform.rotation);
        //获取其他组件
        BoxCollider bc = GetComponent<BoxCollider>();
        //获取子物体的组件
        //GetComponentInChildren <CapsuleCollider>(bc);
        //获取父物体组件
        //GetComponentInParent<>(BoxCollider);
        //添加
        gameObject.AddComponent<AudioSource>();
        //通过游戏物体的名称获取物体
        GameObject test = GameObject.Find("Test");
        Debug.Log(test.name);
        //通过游戏标签获取物体
        test = GameObject.FindWithTag("Player");
        //通过预设体实例化一个游戏物体
        Instantiate(prefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
