using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        Event currentEvent = Event.current;

        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode != KeyCode.None)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                }
                currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;
        }

    }

}
