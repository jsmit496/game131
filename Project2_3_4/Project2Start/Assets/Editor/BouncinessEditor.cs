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
    private float newBounciness;
    private float bounciness;
    private PhysicsMaterial2D bouncinessMat;

    private void Awake()
    {
        bouncinessMat = new PhysicsMaterial2D("pmatBouncy");
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();

        _myTarget = (ChangeBounciness)this.target;
        if (_myTarget.GetComponent<BoxCollider2D>().sharedMaterial != null)
        {
            bouncinessMat = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial;
            bounciness = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
            newBounciness = bounciness;
        }
    }

    public override void OnInspectorGUI()
    {
        bouncinessMat = (PhysicsMaterial2D)EditorGUILayout.ObjectField(bouncinessMat, typeof(PhysicsMaterial2D), false);
        EditorGUILayout.LabelField("Bounciness", bounciness.ToString());
        newBounciness = EditorGUILayout.FloatField("New Bounciness", newBounciness);

        bool applyChange = GUILayout.Button("Apply new bounciness");
        bool reset = GUILayout.Button("Reset");

        _myTarget.GetComponent<BoxCollider2D>().sharedMaterial = bouncinessMat;

        if (applyChange)
        {
           bounciness = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = newBounciness;
        }
        if (reset)
        {
            newBounciness = _myTarget.GetComponent<BoxCollider2D>().sharedMaterial.bounciness;
        }
    }

}
