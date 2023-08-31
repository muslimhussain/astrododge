using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroidSpawer : MonoBehaviour
{
    [SerializeField] private GameObject meteoroid;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float interval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnMeteoroids", interval, interval);
    }

    void Update()
    {
        
    }

    private void SpawnMeteoroids()
    {
        int randomSpawnPointIndex = GetRandomSpawnPoint();
        Instantiate(meteoroid, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
    }
    
    private int GetRandomSpawnPoint()
    {
        return Random.Range(0, spawnPoints.Length);
    }
}
