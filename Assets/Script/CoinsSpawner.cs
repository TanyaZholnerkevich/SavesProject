using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private List<GameObject> coins = new List<GameObject>();

    private float _spawnBorderZ = 18f;
    private float _spawnBorderX = 19f;
    private float _spawnStep = 5f;

    public float[,] spawnCoords;
    private void Start()
    {
        SpawnCoins();
    }

    private void Update()
    {
        for(int i = 0; i < coins.Count; i++)
        {
            if (coins[i].activeInHierarchy == false)
            {
                coins.RemoveAt(i);
                i++;
            }
        }
    }
    private void SpawnCoins()
    {
        if (GameStart.isLoad == false)
        {
            for (float i = -(_spawnBorderZ); i <= _spawnBorderZ; i += _spawnStep)
            {
                var posX = Random.Range(-(_spawnBorderX), _spawnBorderX);
                var coin = Instantiate(coinPrefab, new Vector3(posX, 1, i), Quaternion.identity);
                coins.Add(coin);
            }
        }
        else
        {
            CoinsData coinsData = Saving.LoadCoinsData();
            var dataCoords = coinsData.coords;
            for(int i = 0; i < dataCoords.GetUpperBound(0) + 1; i++)
            {
                var coin = Instantiate(coinPrefab, new Vector3(dataCoords[i, 0], dataCoords[i, 1], dataCoords[i, 2]),
                    Quaternion.identity);
                coins.Add(coin);
            }
        }
    }

    public void SaveCoinsData()
    {
        spawnCoords = new float[coins.Count, 3];
        for (int i = 0; i < coins.Count; i++)
        {
            spawnCoords[i, 0] = coins[i].gameObject.transform.position.x;
            spawnCoords[i, 1] = coins[i].gameObject.transform.position.y;
            spawnCoords[i, 2] = coins[i].gameObject.transform.position.z;
        }
        
        Saving.SaveCoinsData(this);
    }
}
