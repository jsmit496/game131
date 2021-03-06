﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int rows = 10;
    public int cols = 25;
    public float gridSpaceSize = 2.1f;
    public float totalTime = 60f;
    public float gravity = -30f;

    public Color gridColor;

    public AudioClip bgm;
    public Sprite background;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        for (int i = 0; i <= cols; i++)
        {
            Gizmos.DrawLine(new Vector3(i * gridSpaceSize, 0, transform.position.x), 
                new Vector3(i * gridSpaceSize, rows * gridSpaceSize, transform.position.z));
        }

        for (int i = 0; i <= rows; i++)
        {
            Gizmos.DrawLine(new Vector3(0, i * gridSpaceSize, transform.position.z),
                new Vector3(cols * gridSpaceSize, i * gridSpaceSize, transform.position.z));
        }

        SpriteRenderer[] sprites = GameObject.FindObjectsOfType<SpriteRenderer>();

        for (int i = 0; i < sprites.Length; i++)
        {
            //print(sprites.Length);
            SpriteRenderer currentSpriteRenderer = sprites[i];
            Sprite currentSprite = currentSpriteRenderer.sprite;
            Vector3 currentSpriteCenterWorld = currentSpriteRenderer.bounds.center;
            print(currentSprite.name + " is at position " + currentSpriteCenterWorld);

            //How to read "center of sprite is within a grid space"
            //and then lock its corner to the proper grid corner
            Vector3 currentSpriteCenterGrid = new Vector3(Mathf.FloorToInt(currentSpriteCenterWorld.x / gridSpaceSize) * gridSpaceSize,
                                                  Mathf.FloorToInt(currentSpriteCenterWorld.y / gridSpaceSize) * gridSpaceSize,
                                                  0);
            //print(currentSpriteCenterGrid);
            currentSpriteRenderer.transform.position = currentSpriteCenterGrid;
        }
    }
}
