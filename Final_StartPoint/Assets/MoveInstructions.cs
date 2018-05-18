using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstructions : MonoBehaviour {

    public List<Vector3> positions;
    public List<float> ranges;
    public List<Vector3> directions;

    public float moveSpeed = 5.0f;

    private Vector3 moveDirection = new Vector3(0, 0, 1);

    private int dataLength = 0;

	// Use this for initialization
	void Start () {

        int pl = positions.Count, rl = ranges.Count, dl = directions.Count;
        dataLength = pl < rl ? pl : rl;
        dataLength = dl < dataLength ? dl : dataLength;

        // Performance hack: Store range squared so we can compare magnitude squared,
        // eliminating the need for a square root for each target on each update.
        for (int i = 0; i < dataLength; i++) ranges[i] *= ranges[i];

    }

    // Update is called once per frame
    void Update () {

        DetectChangeInMoveDirection();

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

	}

    private void DetectChangeInMoveDirection()
    {
        Vector3 commandDirection = Vector3.zero;
        bool changeDetected = false;
        for (int i = 0; i < dataLength; i++)
        {
            Vector3 position = positions[i];
            float rangeSquared = ranges[i];
            float dx = position.x - transform.position.x, dy = position.z - transform.position.z, distanceSquared = dx * dx + dy * dy;

            if (distanceSquared <= rangeSquared)
            {
                changeDetected = true;
                commandDirection += directions[i];
            }
        }

        if (changeDetected) moveDirection = commandDirection.normalized;
    }
    
}
