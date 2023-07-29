using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpawnerData", menuName = "Spawner/SpawnerData", order = 0)]
public class MonsterSpawnerData : ScriptableObject
{
    // 생성 주기
    [Header("몬스터 생성 주기(초)")]
    [SerializeField] public float monsterCreateTime;

    [Header("몬스터 생성 최대 마리 수")]
    [SerializeField] public int monsterCreateMaxCount;

    [Header("스포너 생성 오브젝트")]
    [SerializeField] public GameObject monsterPrefab;

    [Space(10)]
    [Header("스폰 횟수( -1 = INF)")]
    [SerializeField] public int monsterWaveCount;

    [Header("스폰 범위")]
    [SerializeField] public float spawnRadius;

    private bool isAutoCreate = false;

    public MonsterSpawnerData() 
    {
        monsterCreateTime = .0f;
        monsterCreateMaxCount = 0;
        monsterPrefab = null;
        monsterWaveCount = 0;
        isAutoCreate = false;
        spawnRadius = .0f;
    }

    public MonsterSpawnerData(float createTime, int maxCount, GameObject prefab, int waveCount, float radius)
    {
        monsterCreateTime = createTime;
        monsterCreateMaxCount = maxCount;
        monsterPrefab = prefab;
        monsterWaveCount = waveCount;
        isAutoCreate = false;
        spawnRadius = radius;
    }

    public MonsterSpawnerData GetData()
    {
        return this;
    }

    public void CopyData(MonsterSpawnerData datas)
    {
        if(datas is null)
        {
            return;
        }

        monsterCreateTime = datas.monsterCreateTime;
        monsterCreateMaxCount = datas.monsterCreateMaxCount;
        monsterPrefab = datas.monsterPrefab;
        monsterWaveCount = datas.monsterWaveCount;
        spawnRadius = datas.spawnRadius;

        SetAuto(datas.GetAuto());
    }

    public void SetAuto(bool isOn)
    {
        isAutoCreate = isOn;
    }

    public bool GetAuto()
    {
        return isAutoCreate;
    }
}
