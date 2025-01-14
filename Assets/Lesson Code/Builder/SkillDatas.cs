using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Data", menuName = "Create New Skill Data")]
public class SkillDatas : ScriptableObject
{
    public string skillName;
    public string skillDescription;
    public Sprite skillIcon;
    
    public float cooldown;
    public float damage;
    public float range;
}
