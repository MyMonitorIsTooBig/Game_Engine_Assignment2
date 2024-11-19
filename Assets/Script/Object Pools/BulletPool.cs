using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [Serializable]
    private struct PooledObject
    {
        public Bullet prefab;
        public int numToSpawn;
    }

    [SerializeField] private PooledObject[] pools;

    private static readonly Dictionary<string, Queue<Bullet>> pooledObjects = new Dictionary<string, Queue<Bullet>>();

    private void Awake()
    {
        pooledObjects.Clear();

        foreach(PooledObject pool in pools)
        {
            string name = pool.prefab.name;
            Transform parent = new GameObject(name).transform;
            parent.SetParent(transform);
            Queue<Bullet> objectsToSpawn = new(pool.numToSpawn);
            for(int i = 0; i < pool.numToSpawn; i++)
            {
                Bullet rb = Instantiate(pool.prefab, parent);
                rb.gameObject.SetActive(false);
                objectsToSpawn.Enqueue(rb);
            }

            pooledObjects.Add(name, objectsToSpawn);
        }
    }

    public static Bullet CreateEnemy(string name, Vector3 location, Quaternion rotation)
    {
        if (!pooledObjects.ContainsKey(name))
        {
            Debug.LogAssertion("Pool does not contain key: " + name);
            return null;
        }

        Bullet rb = pooledObjects[name].Dequeue();

        rb.transform.SetPositionAndRotation(location, rotation);
        rb.gameObject.SetActive(true);

        pooledObjects[name].Enqueue(rb);
        return rb;
    }
}
