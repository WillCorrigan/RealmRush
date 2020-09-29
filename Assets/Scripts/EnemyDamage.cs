using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip takenDamageSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();    
    }

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
        myAudioSource.PlayOneShot(takenDamageSFX);
    }

    private void KillEnemy()
    {
        
        var deathAnimation = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathAnimation.Play();
        float destroyDelay = deathAnimation.main.duration;
        Destroy(deathAnimation.gameObject, destroyDelay);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }

}
