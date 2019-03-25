using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem onEnemyHit;
    [SerializeField] ParticleSystem onDeath;

    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        var dfx = Instantiate(onDeath, transform.position, Quaternion.identity);
        dfx.Play();
        Destroy(dfx.gameObject, 1f);
        Destroy(gameObject);

    }

    void ProcessHit()
    {
        hitPoints -= 1;
        onEnemyHit.Play();
    }
}
