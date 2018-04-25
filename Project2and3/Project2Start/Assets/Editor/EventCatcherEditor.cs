using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    private EventCatcher _myTarget;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();

        _myTarget = (EventCatcher)this.target;
    }

    private void OnSceneGUI()
    {
        Event currentEvent = Event.current;
        Vector3 moveUp = _myTarget.transform.position;
        Vector3 scale = _myTarget.transform.localScale;

        UnityEngine.MonoBehaviour.print("Use WASD to move Object");
        UnityEngine.MonoBehaviour.print("Use QE to rotate Object");
        UnityEngine.MonoBehaviour.print("Use RTFG to scale Object");

        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                //Movement
                if (currentEvent.keyCode != KeyCode.LeftShift && currentEvent.keyCode == KeyCode.W)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    moveUp.y += 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.A)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    moveUp.x -= 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.S)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    moveUp.y -= 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.D)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    moveUp.x += 0.1f;
                }
                _myTarget.transform.position = moveUp;

                //Rotation
                if (currentEvent.keyCode == KeyCode.Q)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    _myTarget.transform.Rotate(0, 0, 1f);
                }
                if (currentEvent.keyCode == KeyCode.E)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                    _myTarget.transform.Rotate(0, 0, -1f);
                }

                if (currentEvent.keyCode == KeyCode.R)
                {
                    //scale up X
                    scale.x += 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.T)
                {
                    //scale down X
                    scale.x -= 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.F)
                {
                    //scale down Y
                    scale.y -= 0.1f;
                }
                if (currentEvent.keyCode == KeyCode.G)
                {
                    //scale up Y
                    scale.y += 0.1f;
                }
                _myTarget.transform.localScale = scale;
                break;
        }
    }

}
