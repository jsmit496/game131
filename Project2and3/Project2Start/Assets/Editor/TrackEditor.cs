using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LinkObjects))]
public class TrackEditor : Editor
{
   private LinkObjects _myTarget;

   private SerializedProperty ftrackSpeed;
   private SerializedProperty fdistancePercent;
   private SerializedProperty fdistance;
   private SerializedProperty v3difference;
   private SerializedProperty v3positionForTrackObjects;
   private SerializedProperty objfirstTrackPoint;
   private SerializedProperty objsecondTrackPoint;
   private SerializedProperty objlinkedObject;
   private SerializedProperty firstPointArrow;
   private SerializedProperty secondpointArrow;

   private bool setup = false;

   private void OnEnable()
   {
      _myTarget = (LinkObjects)this.target;

      ftrackSpeed = this.serializedObject.FindProperty("trackSpeed");
      fdistancePercent = this.serializedObject.FindProperty("distancePercent");
      fdistance = this.serializedObject.FindProperty("distance");
      v3difference = this.serializedObject.FindProperty("difference");
      v3positionForTrackObjects = this.serializedObject.FindProperty("distanceBetween");
      objfirstTrackPoint = this.serializedObject.FindProperty("firstTrackPoint");
      objsecondTrackPoint = this.serializedObject.FindProperty("secondTrackPoint");
      objlinkedObject = this.serializedObject.FindProperty("linkedObject");
      firstPointArrow = this.serializedObject.FindProperty("firstTrackArrow");
      secondpointArrow = this.serializedObject.FindProperty("secondTrackArrow");
   }

   public override void OnInspectorGUI()
   {
      if (!setup)
      {
         ftrackSpeed.floatValue = _myTarget.linkedObject.GetComponent<TrackSpeedDir>().defaultTrackSpeed;
      }

      firstPointArrow.objectReferenceValue = _myTarget.firstTrackArrow = (GameObject)EditorGUILayout.ObjectField("First Track Arrow", _myTarget.firstTrackArrow, typeof(GameObject), true);
      secondpointArrow.objectReferenceValue = _myTarget.secondTrackArrow = (GameObject)EditorGUILayout.ObjectField("Second Track Arrow", _myTarget.secondTrackArrow, typeof(GameObject), true);

      if (_myTarget.moveTowardsFirstPoint)
      {
         _myTarget.firstTrackArrow.SetActive(true);
         _myTarget.firstTrackArrow.SetActive(false);
      }
      else
      {
         _myTarget.firstTrackArrow.SetActive(false);
         _myTarget.firstTrackArrow.SetActive(true);
      }

      ftrackSpeed.floatValue = _myTarget.trackSpeed = EditorGUILayout.FloatField("Default Track Speed", _myTarget.trackSpeed);

      objfirstTrackPoint.objectReferenceValue = _myTarget.firstTrackPoint = (GameObject)EditorGUILayout.ObjectField("First Track Point", _myTarget.firstTrackPoint, typeof(GameObject), true);
      objsecondTrackPoint.objectReferenceValue = _myTarget.secondTrackPoint = (GameObject)EditorGUILayout.ObjectField("Second Track Point", _myTarget.secondTrackPoint, typeof(GameObject), true);
      objlinkedObject.objectReferenceValue = _myTarget.linkedObject = (GameObject)EditorGUILayout.ObjectField("Object Linked To Track", _myTarget.linkedObject, typeof(GameObject), true);

      //Calculate difference between points for object
      EditorGUILayout.BeginHorizontal();
      EditorGUILayout.LabelField("Linked Object Position Slider");
      fdistancePercent.floatValue = _myTarget.distancePercent = EditorGUILayout.Slider(_myTarget.distancePercent, 0, 1);
      EditorGUILayout.EndHorizontal();
      fdistance.floatValue = _myTarget.distance = Vector3.Distance(_myTarget.firstTrackPoint.transform.position, _myTarget.secondTrackPoint.transform.position);
      fdistance.floatValue = _myTarget.distance *= _myTarget.distancePercent;
      v3difference.vector3Value = _myTarget.difference = _myTarget.firstTrackPoint.transform.position - _myTarget.secondTrackPoint.transform.position;
      v3difference.vector3Value = _myTarget.difference = _myTarget.difference.normalized * _myTarget.distance;
      v3positionForTrackObjects.vector3Value = _myTarget.distanceBetween = _myTarget.firstTrackPoint.transform.position - _myTarget.difference;

      objlinkedObject.vector3Value = _myTarget.linkedObject.transform.position = _myTarget.distanceBetween;

      this.serializedObject.ApplyModifiedProperties();
   }
}
