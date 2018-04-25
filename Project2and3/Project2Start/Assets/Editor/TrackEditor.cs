using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Track))]
public class TrackEditor : Editor
{
    private Track _myTarget;
    private float defaultTrackSpeed;
    private float trackSpeed;
    private bool setStuff = false;

    private void OnEnable()
    {
        _myTarget = (Track)this.target;
    }

    public override void OnInspectorGUI()
    {
        if (!setStuff)
        {
            trackSpeed = defaultTrackSpeed;
            setStuff = true;
        }

        defaultTrackSpeed = EditorGUILayout.FloatField("Default Track Speed", defaultTrackSpeed);
        trackSpeed = EditorGUILayout.FloatField("Track Speed", trackSpeed);
    }
}
