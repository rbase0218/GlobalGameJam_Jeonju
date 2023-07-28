using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolData : MonoBehaviour
{
    public int maxCount;
    public Transform parent;
    public GameObject prefab;
    
    private List<GameObject> objects;

    public ObjectPoolData()
    {
        maxCount = 0;
        parent = null;
        prefab = null;
        objects = new List<GameObject>();
    }

    public void SetData(ObjectPoolData datas)
    {
        maxCount = datas.maxCount;
        parent = datas.parent;
        objects = datas.objects;
    }

    public void SetData(int count, Transform parent, GameObject prefab)
    {
        this.maxCount = count;
        this.parent = parent;
        this.prefab = prefab;
    }

    public void Create()
    {
        if (maxCount <= 0 || parent is null || prefab is null)
        {
            return;
        }
        
        objects.Clear();

        for (int i = 0; i < maxCount; ++i)
        {
            objects.Add(Add());
        }
    }

    public void Off(GameObject obj)
    {
        if (obj is null)
        {
            return;
        }

        obj.SetActive(false);
    }

    public GameObject Get()
    {
        GameObject obj = objects.Find( x => !x.activeSelf);
        return obj ?? Add();
    }

    private GameObject Add()
    {
        GameObject obj = Instantiate(prefab);
        
        SetObjectData(ref obj);
        objects.Add(obj);

        return objects.Last();
    }

    private void SetObjectData(ref GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        obj.transform.parent = parent;
    }
}

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    private Dictionary<string, ObjectPoolData> poolBuffer;

    private void Awake()
    {
        poolBuffer = new Dictionary<string, ObjectPoolData>();
    }
    
    public void CreateBuffer(string key, int count, Transform parent, GameObject prefab)
    {
        if (HasKey(key))
        {
            DebugWrap.Log($"[ObjectPoolManager] {key}가 중복됩니다.");
            return;
        }
        
        poolBuffer.Add(key, new ObjectPoolData());
        poolBuffer[key].SetData(count, parent, prefab);
        poolBuffer[key].Create();
    }

    public GameObject Get(string key)
    {
        if (!HasKey(key))
        {
            return null;
        }
        
        return poolBuffer[key].Get();
    }

    public void Off(string key, GameObject obj)
    {
        if (HasKey(key))
        {
            poolBuffer[key].Off(obj);
        }
    }
    
    public void DeleteBuffer(string key)
    {
        if (HasKey(key))
        {
            poolBuffer.Remove(key);
        }
    }

    private bool HasKey(string key)
    {
        return poolBuffer.ContainsKey(key);
    }
}
