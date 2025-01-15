using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CreatePlayerComponentEnum : EditorWindow
{
    [MenuItem("Window/Create Player Component Enum")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CreatePlayerComponentEnum));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Create Player Component Enum"))
        {
            ScanPrefabs();
            
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("public enum PlayerComponentsType");
            stringBuilder.AppendLine("{");

            for (int i = 0; i < _componentTypes.Count; i++)
            {
                if (i >= _componentTypes.Count)
                    stringBuilder.AppendLine("\t" + _componentTypes[i].Name);
                else
                    stringBuilder.AppendLine("\t" + _componentTypes[i].Name + ",");
            }
            
            stringBuilder.AppendLine("}");
            
            string filePath = Path.Combine(String.Concat(Application.dataPath, _saveFolder), "PlayerComponentsType.cs");
            
            File.WriteAllText(filePath, stringBuilder.ToString());
            AssetDatabase.Refresh();
        }
    }

    private void ScanPrefabs()
    {
        _componentTypes.Clear();
        
        var prefabPath = Directory.GetFiles(_prefabsFolder, "*.prefab", SearchOption.AllDirectories);
        
        foreach (var assetPath in prefabPath)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

            if (prefab is not null && String.Equals(prefab.name, "Player"))
            {
                HashSet<Component> componentSet = new HashSet<Component>();

                var components = prefab.GetComponentsInChildren<Component>();

                _componentTypes = components.ToList().ConvertAll(component => component.GetType());
                _componentTypes = _componentTypes.Distinct().ToList();

                break;
            }
        }
    }
    
    private List<Type> _componentTypes = new List<Type>();
    
    private readonly string _prefabsFolder = "Assets/03. Prefabs/";
    private readonly string _saveFolder = "/01. Scripts/Player/";
}
