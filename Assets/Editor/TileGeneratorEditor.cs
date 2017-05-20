using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileGenerator))]
public class TileGeneratorEditor : Editor
{
    SerializedProperty tilePrefabProp;

    private void OnEnable()
    {
        tilePrefabProp = serializedObject.FindProperty ("tilePrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(tilePrefabProp, new GUIContent("tilePrefab"));

        if (GUILayout.Button("GenerateTiles"))
        {
            ((TileGenerator)target).GenerateTiles();
        }

        serializedObject.ApplyModifiedProperties();
    }
}