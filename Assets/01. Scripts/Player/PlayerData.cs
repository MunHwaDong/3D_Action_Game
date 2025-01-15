using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int damage;
    public int health;
    public int armor;
    public int speed;
    public int jumpPower;
}
