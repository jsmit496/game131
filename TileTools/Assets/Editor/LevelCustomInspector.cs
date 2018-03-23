using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelCustomInspector : Editor
{
    private Level _myTarget;
    bool setStuff = false;
    bool enableGUI;
    bool originalGUIEnabled = GUI.enabled;
    int newRows;
    int newCols;

    private void OnEnable()
    {
        _myTarget = (Level)this.target;
    }

    public override void OnInspectorGUI()
    {
        //in class examples
        /*
        _myTarget.rows = EditorGUILayout.IntField("Rows", _myTarget.rows);
        _myTarget.cols = EditorGUILayout.IntField("Columns", _myTarget.cols);

        _myTarget.totalTime = EditorGUILayout.FloatField("Current level time", _myTarget.totalTime);
        _myTarget.gravity = EditorGUILayout.FloatField("Gravity Magnitude", _myTarget.gravity);

        _myTarget.bgm = (AudioClip)EditorGUILayout.ObjectField("Background Music", _myTarget.bgm, typeof(AudioClip), true);
        _myTarget.background = (Sprite)EditorGUILayout.ObjectField("Background Display", _myTarget.background, typeof(Sprite), false);

        bool increaseColsumnsByOne = GUILayout.Button("Add Column");
        if (increaseColsumnsByOne)
        {
            _myTarget.cols++;
        }
        */

        //in class exercise
        if (setStuff == false)
        {
            newRows = _myTarget.rows;
            newCols = _myTarget.cols;
            setStuff = true;
        }

        EditorGUILayout.LabelField("Level Rows", _myTarget.rows.ToString());
        EditorGUILayout.LabelField("Level Columns", _myTarget.cols.ToString());

        newRows = EditorGUILayout.IntField("New Row Size", newRows);
        newCols = EditorGUILayout.IntField("New Columns Size", newCols);

        if (newRows != _myTarget.rows || newCols != _myTarget.cols)
        {
            enableGUI = true;
        }
        else
        {
            enableGUI = false;
        }


        //Sets Everything below it to disabled/enabled depending on GUI.enabled state
        GUI.enabled = enableGUI;

        bool ResizeLevel = GUILayout.Button("Resize Level");
        bool Reset = GUILayout.Button("Reset");

        if (ResizeLevel && (newRows != _myTarget.rows || newCols != _myTarget.cols))
        {
            _myTarget.rows = newRows;
            _myTarget.cols = newCols;
        }
        if (Reset)
        {
            newRows = _myTarget.rows;
            newCols = _myTarget.cols;
        }

        //Resets GUI.enabled to its original state at the beginning of the program
        GUI.enabled = originalGUIEnabled;
    }
}
