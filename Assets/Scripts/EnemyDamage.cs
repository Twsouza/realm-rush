using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] ParticleSystem deathParticleSystem;

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
        hitPoints--;
        hitParticleSystem.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(gameObject);
    }
}
