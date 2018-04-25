using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Tools/Level Editor Window")]
    private static void ShowLevelEditor()
    {
        LevelEditorWindow.ShowWindow();
    }
}
