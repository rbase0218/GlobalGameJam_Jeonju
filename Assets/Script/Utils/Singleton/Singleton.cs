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
                Debug.LogWarning($"�� ���� {typeof(T).ToString()} ��(��) �������� �ʽ��ϴ�. \n �̱��� �ʱ�ȭ ���� Instance�� �����ϴ��� Ȯ�� ���ּ���.");
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
                Debug.Log("��");
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