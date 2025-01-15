using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using Assembly = System.Reflection.Assembly;

[InitializeOnLoad]
public class CompileUtility
{
    static CompileUtility()
    {
        EditorApplication.playModeStateChanged += CheckPlayerComponentNumToEnum;
    }

    private static void CheckPlayerComponentNumToEnum(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            var player = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/03. Prefabs/Player.prefab");

            var enumCount = typeof(PlayerComponentsType).GetMembers().
                Where(m => m.MemberType == MemberTypes.Field && m.Name != "value__");

            HashSet<Type> types = new HashSet<Type>();

            var componentsCount = player.GetComponentsInChildren<Component>().Count(c => types.Add(c.GetType()));
            
            if (componentsCount != enumCount.Count())
            {
                Debug.LogError("Not match component count & Enum count");
                EditorApplication.isPlaying = false;
                CreatePlayerComponentEnum.ShowWindow();
            }
        }
    }
    
    
}
