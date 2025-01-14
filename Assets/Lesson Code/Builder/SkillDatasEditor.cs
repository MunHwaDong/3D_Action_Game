using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillDatasEditor : EditorWindow
{
    [MenuItem("Window/Build Skill Datas")]
    public static void ShowWindow()
    {
        GetWindow(typeof(SkillDatasEditor));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Build Skill Datas"))
        {
            
        }
    }
}
