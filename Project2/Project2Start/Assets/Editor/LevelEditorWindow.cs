using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Goal: Add new obstacles and targets within a custom Editor Window
//Additions: ???
public class LevelEditorWindow : EditorWindow
{
    private static LevelEditorWindow customEditor;

    public static void ShowWindow()
    {
        customEditor = EditorWindow.GetWindow<LevelEditorWindow>();
        customEditor.titleContent = new GUIContent("Level Editor");
    }

    private void OnGUI()
    {
        
    }

}
