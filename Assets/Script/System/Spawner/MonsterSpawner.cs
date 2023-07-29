using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;

public class MonsterSpawner : MonoBehaviour
{
    [field: SerializeField] public MonsterSpawnerData SpawnData { get; private set; }

    public UnityEvent spawnEvent;
    public UnityEvent destroyEvent;
    
    private MonsterSpawnerData copyData;
    private float timer = .0f;
    private int previousCount = 0;

    private const int INF = -1;


    private bool isPlay = false;

    private void Awake()
    {
        if (SpawnData is null)
        {
            Debug.Log($"{SpawnData} {Debug.GetErrorMsg()}");
            Debug.Break();
        }
        else
        {
            SetUp();
            
            ObjectPoolManager.Instance.CreateBuffer("MONSTER", 10, this.transform, SpawnData.monsterPrefab);
        }

        // Auto 생성 진행한다.
        SetAuto(true);
    }

    private void Update()
    {
        if (!copyData.GetAuto() || !isPlay)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= copyData.monsterCreateTime && isPlay)
        {
            Spawn();

            timer = .0f;
        }
    }

    #region Process
    private void SetUp()
    {
        if (copyData is null)
        {
            copyData = ScriptableObject.CreateInstance<MonsterSpawnerData>();
        }

        copyData.CopyData(SpawnData);
        isPlay = true;
    }
    #endregion

    public void Restart()
    {
        SetUp();
    }

    public void SetWaveCount(int count)
    {
        copyData.monsterWaveCount = count;
    }

    public void SetMaxCreateMonsterCount(int count)
    {
        copyData.monsterCreateMaxCount = count;
    }

    public void SetCreateTime(float time)
    {
        copyData.monsterCreateTime = time;
    }

    public void Spawn(int count)
    {
        if (copyData.GetAuto() || !isPlay)
        {
            return;
        }

        previousCount = copyData.monsterCreateMaxCount;

        SetMaxCreateMonsterCount(count);

        Spawn();

        SetMaxCreateMonsterCount(previousCount);
    }

    public void OnFalse()
    {
        destroyEvent?.Invoke();

        isPlay = false;
        gameObject.SetActive(false);
    }

    public void SetAuto(bool isOn)
    {
        copyData.SetAuto(isOn);
    }

    private void Spawn()
    {
        if (copyData.monsterWaveCount == INF || copyData.monsterWaveCount > 0)
        {
            spawnEvent?.Invoke();

            for (int i = 0; i < copyData.monsterCreateMaxCount; ++i)
            {
                Debug.Log($"몬스터 스폰 {i}");

                var obj = ObjectPoolManager.Instance.Get("MONSTER");
                obj.transform.position = GetSpawnPos(copyData.spawnRadius);
                
                obj.SetActive(true);
            }

            copyData.monsterWaveCount -= (copyData.monsterWaveCount != INF) ? 1 : 0;
        }

        if (copyData.monsterWaveCount != INF && copyData.monsterWaveCount <= 0)
        {
            OnFalse();
        }
    }

    private Vector3 GetSpawnPos(float radius)
    {
        return new Vector3(Random.Range(transform.position.x - radius, transform.position.x + radius), transform.position.y, Random.Range(transform.position.z - radius, transform.position.z + radius));
    }
}
