using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleAttack : MonoBehaviour
{
    
    public static bool isAlive = true;

    void Start()
    {
        isAlive = true;
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