using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinsData
{
    public float[,] coords;

    public CoinsData(CoinsSpawner coinsSpawner)
    {
        coords = coinsSpawner.spawnCoords;
    }
}
