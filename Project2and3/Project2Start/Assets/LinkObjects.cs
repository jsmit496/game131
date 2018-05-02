using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkObjects : MonoBehaviour
{
    public GameObject firstTrackPoint;
    public GameObject secondTrackPoint;
    public GameObject linkedObject;
    public float distancePercent;
    public bool moveTowardsFirstPoint = true;

    public Vector3 distanceBetween;
    public Vector3 difference;
    public float trackSpeed;
    public float distance;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveTowardsFirstPoint && distancePercent > 0)
        {
            distancePercent -= 0.1f * Time.deltaTime * trackSpeed;
            if (distancePercent <= 0)
            {
                distancePercent = 0;
                moveTowardsFirstPoint = !moveTowardsFirstPoint;
            }
        }
        else if (!moveTowardsFirstPoint && distancePercent < 1)
        {
            distancePercent += 0.1f * Time.deltaTime * trackSpeed;
            if (distancePercent >= 1)
            {
                distancePercent = 1;
                moveTowardsFirstPoint = !moveTowardsFirstPoint;
            }
        }
        linkedObject.transform.position = distanceBetween;
        print(distanceBetween);

        distance = Vector3.Distance(firstTrackPoint.transform.position, secondTrackPoint.transform.position);
        distance *= distancePercent;
        difference = firstTrackPoint.transform.position - secondTrackPoint.transform.position;
        difference = difference.normalized * distance;
        distanceBetween = firstTrackPoint.transform.position - difference;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(firstTrackPoint.transform.position, secondTrackPoint.transform.position);
    }
}
