using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameTime))]
public class GameTimeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        GUILayout.Label("TimeScale: " + Time.timeScale);
        Time.timeScale = GUILayout.HorizontalSlider(Time.timeScale, 0.0F, 10.0f);
    }
}