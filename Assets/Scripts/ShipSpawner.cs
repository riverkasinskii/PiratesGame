using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> shipViewPrefab;
    [SerializeField] private int countShip = 5;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnTime = 4f;

    private List<GameObject> poolShips;

    private void Start()
    {
        poolShips = new List<GameObject>();
        for (int i = 0; i < shipViewPrefab.Count; i++)
        {
            GameObject ship = Instantiate(shipViewPrefab[i]);
            ship.SetActive(false);
            for (int j = 0; j < countShip; j++)
            {
                poolShips.Add(ship);
            }
        }        
        StartCoroutine(SpawnShip());
    }

    private IEnumerator SpawnShip()
    {        
        while (true)
        {
            int limit;
            if (Stats.Level < shipViewPrefab.Count)
            {
                limit = Stats.Level;
            }
            else
            {
                limit = shipViewPrefab.Count;
            }          
            GameObject ship = poolShips[Random.Range(0, poolShips.Count)];
            ship.transform.SetPositionAndRotation(
                spawnPoints[Random.Range(0, spawnPoints.Count)].position,
                Quaternion.identity);
            ship.SetActive(true);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
