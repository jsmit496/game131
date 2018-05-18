using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveInstructions))]
public class MoveEditor : Editor
{
    private MoveInstructions _myTarget;
    private int numWaypoints;
    private float range;
    private GameObject checkpoints;
    private Vector3 direction;
    private bool add;
    private bool remove;

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
        _myTarget = (MoveInstructions)this.target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        checkpoints = (GameObject)EditorGUILayout.ObjectField("Point To Reach", checkpoints, typeof(GameObject), true);
        range = EditorGUILayout.FloatField("Point Range", range);

        add = GUILayout.Button("Add Point");
        remove = GUILayout.Button("Remove All Points");

        if (add)
        {
            _myTarget.positions.Add(checkpoints.transform.position);
            _myTarget.ranges.Add(range);
            if (_myTarget.directions.Count < 1)
            {
                _myTarget.directions.Add(checkpoints.transform.position - _myTarget.gameObject.transform.position);
            }
            else
            {
                //Error when you reach this point
                _myTarget.directions.Add(checkpoints.transform.position - _myTarget.directions[_myTarget.directions.Count]);
            }
            UnityEngine.MonoBehaviour.print(_myTarget.directions.Count);
        }

        if (remove)
        {
            _myTarget.positions = new List<Vector3>();
            _myTarget.directions = new List<Vector3>();
            _myTarget.ranges = new List<float>();
        }
    }
}
