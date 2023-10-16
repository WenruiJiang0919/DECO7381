using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //场景类，场景管理类
        //SceneManager.LoadScene(1);
        //获取当前场景
        Scene scene = SceneManager.GetActiveScene();
        //名称
        Debug.Log(scene.name);
        //是否已经加载
        Debug.Log(scene.isLoaded);
        //
        Debug.Log(scene.path);
        //
        Debug.Log(scene.buildIndex);
        //
        GameObject[] turple = scene.GetRootGameObjects();
        //
        Debug.Log(SceneManager.sceneCount);
        //
        //Scene newScene = SceneManager.CreateScene("newScene");
        //SceneManager.UnloadSceneAsync(newScene);
        //SceneManager.LoadScene("newScene", LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
