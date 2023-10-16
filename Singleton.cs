using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                /*if (_instance == null)
                {
                    Debug.LogError("Singleton instance of type " + typeof(T) + " not found in the scene.");
                }*/
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Debug.LogWarning("Duplicate Singleton of type " + typeof(T) + " found. Destroying the new one.");
            Destroy(gameObject);
        }
    }
}
//source：https://www.bilibili.com/video/BV1tB4y1J7ra/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=e81b410a72e94322b76cd65e6b58772b
