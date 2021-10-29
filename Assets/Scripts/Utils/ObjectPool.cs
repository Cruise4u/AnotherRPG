using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectPoolRef
{
    HolystrikePool,
    AnotherObjectPool,
    SomeOtherObjectPool,
}

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public ObjectPoolRef objectPoolReference;
        public GameObject poolPrefab;
        public int poolSize;
    }

    public static ObjectPool Instance;
    public List<Pool> poolList;
    public Dictionary<ObjectPoolRef, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        Instance = this;
        AllocatePool();
    }

    public void AllocatePool()
    {
        poolDictionary = new Dictionary<ObjectPoolRef, Queue<GameObject>>();
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                if(pool.poolPrefab != null)
                {
                    var instanceGO = Instantiate(pool.poolPrefab);
                    instanceGO.SetActive(false);
                    poolQueue.Enqueue(instanceGO);
                }
            }

            poolDictionary.Add(pool.objectPoolReference, poolQueue);
        }
    }

    public void ReturnToPool(ObjectPoolRef poolName,GameObject obj)
    {
        obj.SetActive(false);
        poolDictionary[poolName].Enqueue(obj);
    }

    public GameObject SpawnPoolObject(ObjectPoolRef poolName, Vector3 position)
    {
        GameObject spawnGO = poolDictionary[poolName].Dequeue();
        spawnGO.SetActive(true);
        spawnGO.transform.position = position;
        return spawnGO;
    }

    public virtual IEnumerator ReturnAbilityRoutine(ObjectPoolRef poolName,GameObject instance, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnToPool(poolName, instance);
    }
}






