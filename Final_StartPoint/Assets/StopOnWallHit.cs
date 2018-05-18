using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnWallHit : MonoBehaviour {

    Dictionary<Transform, bool> hitCheckpoints = new Dictionary<Transform, bool>();

	// Use this for initialization
	void Start () {
        print("Max score is " + GameObject.FindGameObjectsWithTag("Checkpoint").Length);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            print("Final score: " + hitCheckpoints.Count);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        if (other.tag == "Checkpoint")
        {
            if (!hitCheckpoints.ContainsKey(other.transform))
            {
                hitCheckpoints.Add(other.transform, true);
            }
        }

    }


}
