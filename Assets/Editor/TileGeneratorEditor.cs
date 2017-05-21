using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileGenerator))]
public class TileGeneratorEditor : Editor
{
	SerializedProperty tilePrefabProp;
    SerializedProperty waterProp;
    SerializedProperty scaleProp;
    SerializedProperty varianceProp;

    private void OnEnable()
    {
        waterProp = serializedObject.FindProperty("water");
        tilePrefabProp = serializedObject.FindProperty ("tilePrefab");
		scaleProp = serializedObject.FindProperty ("noiseScale");
		varianceProp = serializedObject.FindProperty ("heightVariance");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(waterProp, new GUIContent("water"));
        EditorGUILayout.PropertyField(tilePrefabProp, new GUIContent("tilePrefab"));
		EditorGUILayout.PropertyField(scaleProp, new GUIContent("noiseScale"));
		EditorGUILayout.PropertyField(varianceProp, new GUIContent("heightVariance"));

        if (GUILayout.Button("GenerateTiles"))
        {
            ((TileGenerator)target).GenerateTiles();
        }

        serializedObject.ApplyModifiedProperties();
    }
}