using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 25;


    void OnTriggerEnter(Collider other)
    {
        
        CastleAttack castle = other.GetComponent<CastleAttack>();
        if (castle != null)
        {
            Debug.Log("attack");
            castle.TakeDamage(damage);
        }
    }
}
