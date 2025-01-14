using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/Skill Data")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public float cooldown;
}
