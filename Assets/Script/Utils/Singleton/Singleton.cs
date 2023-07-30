using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public bool IsDontDestroy = true;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning($"씬 내에 {typeof(T).ToString()} 이(가) 존재하지 않습니다. \n 싱글톤 초기화 전에 Instance를 접근하는지 확인 해주세요.");
                return null;
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        Debug.Log(instance);

        if (instance == null)
        {
            Debug.Log("2");

            instance = this as T;

            if (IsDontDestroy)
            {
                Debug.Log("들어가");
                instance.transform.name += instance.transform.name + "_Singleton";
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Debug.Log(instance.transform.name);

            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        instance = null;
    }
}