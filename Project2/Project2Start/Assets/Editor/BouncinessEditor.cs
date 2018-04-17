using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Bugs:
//1. Causes all objects to change bounciness that have the script instead of just one.

[CustomEditor(typeof(ChangeBounciness))]
public class BouncinessEditor : Editor
{
    private ChangeBounciness _myTarget;
    float newBounciness;
    bool setStuff = false;

    private void OnEnable()
    {
        _myTarget = (ChangeBounciness)this.target;
    }

    public override void OnInspectorGUI()
    {
        if (setStuff == false)
        {
            newBounciness = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
            setStuff = true;
        }

        //EditorGUILayout.LabelField("Bounciness", _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness.ToString());
        EditorGUILayout.LabelField("Another Bounciness", this._myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness.ToString());
        newBounciness = EditorGUILayout.FloatField("New Bounciness", newBounciness);

        bool applyChange = GUILayout.Button("Apply new bounciness");
        bool reset = GUILayout.Button("Reset");

        if (applyChange)
        {
            this._myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = newBounciness;
        }
        if (reset)
        {
            newBounciness = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
        }
    }

}
