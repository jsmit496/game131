using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

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
        CreateEditorButton("Create Target", "Target");
        CreateEditorButton("Create WallBase", "wallBase 1");
        CreateEditorButton("Create Track", "Track");
        CreateEditorButton("Create Crossbow", "crossbowRoot");
    }

    public static void CreateEditorButton(string buttonName, string objectName)
    {
        Vector3 defPos = new Vector3(0, 0, 0);

        if (GUILayout.Button(buttonName))
        {
            string[] objectGuids = AssetDatabase.FindAssets(objectName);

            if (objectGuids.Length > 0)
            {
                string trueObjectGuid = objectGuids[0];

                string assetPath = AssetDatabase.GUIDToAssetPath(trueObjectGuid);

                GameObject objectTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject newObject = Instantiate(objectTemplate);
                newObject.name = objectTemplate.name;
                newObject.transform.position = defPos;
            }
        }
    }

}
