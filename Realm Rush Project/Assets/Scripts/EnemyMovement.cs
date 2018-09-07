using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

    // Use this for initialization
	void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();

    }
    private void SelfDestruct()
    {
        // could also have childed this to enemy and simply played it
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        // destroy particle after delay (can't use destroy gameobject, because gets rid of script)
        Destroy(vfx.gameObject, destroyDelay); // NEED vfx.gameobject, vfx is the effect itself
        Destroy(gameObject);
    }

}
