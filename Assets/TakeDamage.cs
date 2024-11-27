using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TakeDamage : MonoBehaviour
{
    public static int ghealth = 100;
    public int health;

    public int deathScore = 10;
    
    public ParticleSystem damageParticles;
    public ParticleSystem deathParticles;
    
    [SerializeField] Canvas canvas;
    [SerializeField] Slider healthSlider;

    void Start()
    {
        health = ghealth;

        if (healthSlider)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
            healthSlider.minValue = 0;
        }
        canvas.enabled = false;
    }

    void Update()
    {
        if(ZombieSpawn.HealthUpgrade) UpgradeZombies();
    }

    public void GetDamage(int damage)
    {
        canvas.enabled = true;
        health -= damage;
        damageParticles.Play();
        

        if(healthSlider) healthSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // deathParticles.transform.parent = null;
        // deathParticles.Play();
        // Destroy(deathParticles.gameObject, deathParticles.main.duration);
        Destroy(gameObject);
        
        
        Upgrade.score += deathScore;
    }

    public void UpgradeZombies()
    {
        ghealth += 1;
        Debug.Log("health " + health);
        
        ZombieSpawn.HealthUpgrade = false;
        
    }
        
}
