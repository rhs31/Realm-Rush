using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab; // could also use an interface or inheritance if we want to ensure it's an enemy

    // Use this for initialization
	void Start () {
		// start a co-routine
	}
	
	// coroutine thing
        // forever
            // spawn enemy
            //wait a bit
}
