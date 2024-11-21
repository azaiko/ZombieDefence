using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int health = 100;

    public int deathScore = 10;
    
    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem deathParticles;

    public void GetDamage(int damage)
    {
        health -= damage;
        damageParticles.Play();
        Debug.Log(health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        deathParticles.Play();
        Upgrade.score += deathScore;
        ZombieSpawn.currentEnemyCount--;
    }
}
