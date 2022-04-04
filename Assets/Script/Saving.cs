using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
    public static void SavePlayerData(PlayerController playerController)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/playerData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(playerController);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static void SaveEnemiesData(EnemiesSpawner enemiesSpawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/enemiesData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        EnemiesData enemiesData = new EnemiesData(enemiesSpawner);
        formatter.Serialize(stream, enemiesData);
        stream.Close();
    }
    public static void SaveCoinsData(CoinsSpawner coinsSpawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/coinsData.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        CoinsData coinsData = new CoinsData(coinsSpawner);
        formatter.Serialize(stream, coinsData);
        stream.Close();
    }
    
    public static PlayerData LoadPlayerData()
    {
        var path = Application.persistentDataPath + "/playerData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Path not found");
            return null;
        }
    }
    public static EnemiesData LoadEnemiesData()
    {
        var path = Application.persistentDataPath + "/enemiesData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            EnemiesData enemiesData = formatter.Deserialize(stream) as EnemiesData;
            stream.Close();

            return enemiesData;
        }
        else
        {
            Debug.LogError("Path not found");
            return null;
        }
    }
    public static CoinsData LoadCoinsData()
    {
        var path = Application.persistentDataPath + "/coinsData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CoinsData coinsData = formatter.Deserialize(stream) as CoinsData;
            stream.Close();

            return coinsData;
        }
        else
        {
            Debug.LogError("Path not found");
            return null;
        }
    }
}
