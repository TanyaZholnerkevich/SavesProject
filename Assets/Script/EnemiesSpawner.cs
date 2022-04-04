using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();

    private float _spawnBorderZ = 18f;
    private float _spawnBorderX = 19f;
    private float _spawnStep = 4f;
    
    public float[,] spawnCoords;
    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (GameStart.isLoad == false)
        {
            SpawnNewEnemies();
        }
        else
        {
            SpawnLoadedEnemies();
        }
    }
    private void SpawnNewEnemies()
    {
        for (float i = -(_spawnBorderZ); i <= _spawnBorderZ; i += _spawnStep)
        {
            var posX = Random.Range(-(_spawnBorderX), _spawnBorderX);
            var enemy = Instantiate(enemyPrefab, new Vector3(posX, 1, i), Quaternion.identity);
            enemies.Add(enemy);
        } 
    }

    private void SpawnLoadedEnemies()
    {
         EnemiesData enemiesData = Saving.LoadEnemiesData();
         var dataCoords = enemiesData.coords;
         for(int i = 0; i < dataCoords.GetUpperBound(0) + 1; i++)
         {
             var enemy = Instantiate(enemyPrefab, new Vector3(dataCoords[i, 0], dataCoords[i, 1], dataCoords[i, 2]),
                 Quaternion.identity);
             enemies.Add(enemy);
         }
    }
    private void Update()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].activeInHierarchy == false)
            {
                enemies.RemoveAt(i);
                i++;
            }
        }
    }

    public void SaveEnemiesData()
    {
        spawnCoords = new float[enemies.Count, 3];
        for (int i = 0; i < enemies.Count; i++)
        {
            spawnCoords[i, 0] = enemies[i].gameObject.transform.position.x;
            spawnCoords[i, 1] = enemies[i].gameObject.transform.position.y;
            spawnCoords[i, 2] = enemies[i].gameObject.transform.position.z;
        }
        
        Saving.SaveEnemiesData(this);
    }
}