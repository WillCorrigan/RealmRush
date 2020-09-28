using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 0.5f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(enemyMoveSpeed);
        }

        KillEnemy();
    }


    private void KillEnemy()
    {
        var deathAnimation = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        deathAnimation.Play();
        float destroyDelay = deathAnimation.main.duration;
        Destroy(deathAnimation.gameObject, destroyDelay);
        Destroy(gameObject);
    }
}


