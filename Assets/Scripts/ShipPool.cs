using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> shipViewPrefab;
    [SerializeField] private int countShip = 5;
    [SerializeField] private List<Transform> spawnPoints;

    [Range(2, 10)]
    [SerializeField] private float spawnTime;
    
    private List<GameObject> poolShips;

    private void Start()
    {
        InitializePool();
        StartCoroutine(SpawnShip());
    }

    private void InitializePool()
    {
        poolShips = new List<GameObject>();
        for (int i = 0; i < shipViewPrefab.Count; i++)
        {
            for (int j = 0; j < countShip; j++)
            {
                GameObject ship = Instantiate(shipViewPrefab[i]);
                ship.SetActive(false);
                poolShips.Add(ship);
            }
        }
    }

    private IEnumerator SpawnShip()
    {        
        while (true)
        {       
            GameObject ship = poolShips[Random.Range(0, poolShips.Count)];
            if (!ship.activeSelf)
            { 
                ship.transform.SetPositionAndRotation(
                spawnPoints[Random.Range(0, spawnPoints.Count)].position,
                Quaternion.identity);    
                ship.SetActive(true);                
            }
            else
            {
                continue;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
