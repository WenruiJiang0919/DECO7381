using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�����࣬����������
        //SceneManager.LoadScene(1);
        //��ȡ��ǰ����
        Scene scene = SceneManager.GetActiveScene();
        //����
        Debug.Log(scene.name);
        //�Ƿ��Ѿ�����
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
