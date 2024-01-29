using Assets.Scripts;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BootStrap))]
public class SelectGameConfig : Editor
{

    private SerializedProperty selectedConfig;
    int index = 0;
    private string[] configNames;
    private string[] configs;

    private void OnEnable()
    {
        selectedConfig = serializedObject.FindProperty("config");
        CacheConfigs();
    }

    private void CacheConfigs()
    {
        configs = AssetDatabase.FindAssets("t:GameSettings");
        configNames = new string[configs.Length];
        for (int i = 0; i < configs.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(configs[i]);
            GameSettings config = AssetDatabase.LoadAssetAtPath<GameSettings>(path);
            configNames[i] = config.name;
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        BootStrap script = (BootStrap)target;
        GUIContent configsLabel = new GUIContent("Configs");
        index = EditorGUILayout.Popup(configsLabel, index, configNames);
        GameSettings newConfig = AssetDatabase.LoadAssetAtPath<GameSettings>(AssetDatabase.GUIDToAssetPath(configs[index]));
        if (newConfig != null)
        {
            Debug.Log("newConfig is Updated");
            selectedConfig.objectReferenceValue = newConfig;
            script.config = newConfig;
        }
        else
        {
            Debug.LogError("Failed to load selected config!");
        }
        DrawDefaultInspector();
        serializedObject.ApplyModifiedProperties();
        script.config = (GameSettings)selectedConfig.objectReferenceValue;
    }


}

