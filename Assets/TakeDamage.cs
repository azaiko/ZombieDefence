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
    public int health = 100;

    public int deathScore = 10;
    
    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem deathParticles;
    
    [SerializeField] Canvas canvas;
    [SerializeField] Slider healthSlider;

    void Start()
    {

        if (healthSlider)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
            healthSlider.minValue = 0;
        }
        canvas.enabled = false;
    }

    public void GetDamage(int damage)
    {
        canvas.enabled = true;
        health -= damage;
        // damageParticles.Play();
        //Debug.Log(health);
        if(healthSlider) healthSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        
        Upgrade.score += deathScore;
    }
}
