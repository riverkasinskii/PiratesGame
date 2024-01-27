using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{    
    public static ProjectilePool Instance;
    public List<ProjectileConfig> config;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        Instance = this;
    }
        
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in config)
        {
            Queue<GameObject> objectPool = new();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);                
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
