using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }


    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        var deathAnimation = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathAnimation.Play();
        float destroyDelay = deathAnimation.main.duration;
        Destroy(deathAnimation.gameObject, destroyDelay);
        Destroy(gameObject);
    }

}
