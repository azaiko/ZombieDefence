using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleAttack : MonoBehaviour
{
    public int health = 1000;
    public Text healthText;

    void Start()
    {
        healthText.text = "Health: " + health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
        healthText.text = "Health: " + health;   
    }

    public void Die()
    {
        Destroy(gameObject);
        
    }
}
