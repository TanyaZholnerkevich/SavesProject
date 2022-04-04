using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesData
{
    public float[,] coords;

    public EnemiesData(EnemiesSpawner enemiesSpawner)
    {
        coords = enemiesSpawner.spawnCoords;
    }
}
