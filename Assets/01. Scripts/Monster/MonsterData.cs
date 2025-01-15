using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public float speed;
    public float health;
    public float damage;
    public float armor;
    public Vector3 visibleArea;
}
