using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleAttack : MonoBehaviour
{
    public int health = 1000;
    //public Text healthText;
    public static bool isAlive = true;

    void Start()
    {
        GameManager.instance.uiController.UpdateHealth(health);
    }
    
    public void TakeDamage(int damage)
    {
        GameManager.instance.TakeDamage(damage);
    }

    public void Die()
    {
        isAlive = false;
        Destroy(gameObject);
        
    }
}