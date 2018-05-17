using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    private EventCatcher _myTarget;
    //private SerializedProperty mode;
    private int modeChoice = 1;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();1
        EditorGUILayout.LabelField("Use WASD to manipulate the object");
        EditorGUILayout.LabelField("Current Mode: ", _myTarget.mode);
        EditorGUILayout.LabelField("Press 1 to enable moving the object");
        EditorGUILayout.LabelField("Press 2 to enable rotating the object");
        EditorGUILayout.LabelField("Press 3 to enable scaling the object");
        //this.serializedObject.ApplyModifiedProperties();
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();

        _myTarget = (EventCatcher)this.target;
        //mode = this.serializedObject.FindProperty("mode");
    }

    private void OnSceneGUI()
    {
        Event currentEvent = Event.current;
        Vector3 moveUp = _myTarget.transform.position;
        Vector3 scale = _myTarget.transform.localScale;

        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.W)
                {
                    if (modeChoice == 1)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        moveUp.y += 0.1f;
                        Event.current.Use();
                    }
                    else if (modeChoice == 2)
                    {

                    }
                    else if (modeChoice == 3)
                    {
                        //scale up X
                        scale.x += 0.1f;
                        Event.current.Use();
                    }
                }
                if (currentEvent.keyCode == KeyCode.A)
                {
                    if (modeChoice == 1)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        moveUp.x -= 0.1f;
                        Event.current.Use();
                    }
                    else if (modeChoice == 2)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        _myTarget.transform.Rotate(0, 0, 1f);
                        Event.current.Use();
                    }
                    else if (modeChoice == 3)
                    {
                        //scale down Y
                        scale.y -= 0.1f;
                        Event.current.Use();
                    }
                }
                if (currentEvent.keyCode == KeyCode.S)
                {
                    if (modeChoice == 1)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        moveUp.y -= 0.1f;
                        Event.current.Use();
                    }
                    else if (modeChoice == 2)
                    {

                    }
                    else if (modeChoice == 3)
                    {
                        //scale down X
                        scale.x -= 0.1f;
                        Event.current.Use();
                    }
                }
                if (currentEvent.keyCode == KeyCode.D)
                {
                    if (modeChoice == 1)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        moveUp.x += 0.1f;
                        Event.current.Use();
                    }
                    else if (modeChoice == 2)
                    {
                        UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                        _myTarget.transform.Rotate(0, 0, -1f);
                        Event.current.Use();
                    }
                    else if (modeChoice == 3)
                    {
                        //scale up Y
                        scale.y += 0.1f;
                        Event.current.Use();
                    }
                }
                _myTarget.transform.position = moveUp;
                _myTarget.transform.localScale = scale;

                if (currentEvent.keyCode == KeyCode.Alpha1)
                {
                    modeChoice = 1;
                    _myTarget.mode = "MOVE";
                    Event.current.Use();
                }
                if (currentEvent.keyCode == KeyCode.Alpha2)
                {
                    modeChoice = 2;
                    _myTarget.mode = "ROTATE";
                    Event.current.Use();
                }
                if (currentEvent.keyCode == KeyCode.Alpha3)
                {
                    modeChoice = 3;
                    _myTarget.mode = "SCALE";
                    Event.current.Use();
                }

                break;
        }
    }

}
