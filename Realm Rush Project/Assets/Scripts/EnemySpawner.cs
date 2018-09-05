using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab; // could also use an interface or inheritance if we want to ensure it's an enemy

    // Use this for initialization
	void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
	}
	
    IEnumerator RepeatedlySpawnEnemies()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
       
    }

}
