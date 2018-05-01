using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LinkObjects))]
public class TrackEditor : Editor
{
    private LinkObjects _myTarget;
    private float defaultTrackSpeed;
    private float distancePercent;
    private float distance;
    private Vector3 difference;
    private Vector3 positionForTrackObject;

    private void OnEnable()
    {
        _myTarget = (LinkObjects)this.target;
    }

    public override void OnInspectorGUI()
    {
        defaultTrackSpeed = EditorGUILayout.FloatField("Default Track Speed", defaultTrackSpeed);

        _myTarget.firstTrackPoint = (GameObject)EditorGUILayout.ObjectField("First Track Point", _myTarget.firstTrackPoint, typeof(GameObject), true);
        _myTarget.secondTrackPoint = (GameObject)EditorGUILayout.ObjectField("Second Track Point", _myTarget.secondTrackPoint, typeof(GameObject), true);
        _myTarget.linkedObject = (GameObject)EditorGUILayout.ObjectField("Object Linked To Track", _myTarget.linkedObject, typeof(GameObject), true);

        //Calculate difference between points for object
        EditorGUILayout.LabelField("Linked Object Position Slider");
        _myTarget.distancePercent = EditorGUILayout.Slider(_myTarget.distancePercent, 0, 1);
        _myTarget.distance = Vector3.Distance(_myTarget.firstTrackPoint.transform.position, _myTarget.secondTrackPoint.transform.position);
        _myTarget.distance *= _myTarget.distancePercent;
        _myTarget.difference = _myTarget.firstTrackPoint.transform.position - _myTarget.secondTrackPoint.transform.position;
        _myTarget.difference = _myTarget.difference.normalized * _myTarget.distance;
        _myTarget.distanceBetween = _myTarget.firstTrackPoint.transform.position - _myTarget.difference;

        _myTarget.linkedObject.transform.position = _myTarget.distanceBetween;
    }
}
