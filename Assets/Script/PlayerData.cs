using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int coins;
    public int level;
    public float posX;
    public float posY;
    public float posZ;

    public PlayerData(PlayerController playerController)
    {
        health = playerController.health;
        coins = playerController.coins;
        level = playerController.level;
        posX = playerController.playerPos.x;
        posY = playerController.playerPos.y;
        posZ = playerController.playerPos.z;
    }
}