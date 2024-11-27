using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static float gspeed = 10; 
    public float speed;
    public int spot = 0;
    public int next = 1;
    public Transform[] spots;
    private Animator anim;
    private bool isAttacking = false;

    void Start()
    {
        speed = gspeed;
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
    }

    void Update()
    {
        if (ZombieSpawn.SpeedUpgrade)
        {
            UpgradeOfSpeed();
        }
        
        if (isAttacking)
        {
            return;
        }
        
        transform.LookAt(spots[spot].position);
        
        transform.position = Vector3.MoveTowards(transform.position, spots[spot].position, Time.deltaTime * speed);
        
        
        if (Vector3.Distance(transform.position, spots[spot].position) < 0.1f)
        {
            if (spot == spots.Length - 1)
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Run", false);
                isAttacking = true;
                return; 
            }
            
            if (spot == 0)
            {
                next = 1;
            }
            
            spot += next;
        }
    }

    void UpgradeOfSpeed()
    {
        gspeed += 0.1f;
        Debug.Log("speed upgraded " + speed);
        ZombieSpawn.SpeedUpgrade = false;
    }

}