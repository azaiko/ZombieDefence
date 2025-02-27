using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 10f;  // Радиус действия турели
    public int attackDamage = 10; // Урон от атаки
    public float attackRate = 1f;    // Частота атак (время между выстрелами)

    [SerializeField] private Transform turret;

    private Transform currentTarget; // Текущая цель (зомби)
    private float lastAttackTime;    // Время последней атаки
    public static List<GameObject> zombies = new List<GameObject>();

    private TurretInfoUI updateUI;

    void Start()
    {
        UpdateZombieList();
        updateUI = FindObjectOfType<TurretInfoUI>();
        if (updateUI == null)
        {
            Debug.LogError("TurretInfoUI not found on the scene!");
        }

    }
    
    void FixedUpdate()
    {
        UpdateZombieList();
        FindNearestEnemy();

        if (currentTarget != null)
        {
            RotateTurret();
            AttackEnemy();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                updateUI.ShowPannel(this);
                
                
            }
        }
    }
    

    void UpdateZombieList()
    {
        zombies.Clear();
        zombies.AddRange(GameObject.FindGameObjectsWithTag("Zombie"));
    }

    void FindNearestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform nearestZombie = null;

        foreach (GameObject zombie in zombies)
        {
            if (zombie != null) 
            {
                float distance = Vector3.Distance(transform.position, zombie.transform.position);
                if (distance <= attackRange && distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestZombie = zombie.transform;
                }
            }
        }

        currentTarget = nearestZombie;
    }
    void RotateTurret()
    {
        if (currentTarget == null) 
        {
            Debug.Log("No target to rotate towards.");
            return;
        }

        // Рассчитываем направление к цели
        Vector3 direction = currentTarget.position - transform.position;

        // Убираем вертикальную составляющую, чтобы вращение происходило только вокруг оси Y
        

        if (direction.magnitude < 0.1f)
        {
            Debug.LogWarning("Target is too close or invalid for rotation.");
            return;
        }

        // Рассчитываем целевую ориентацию
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        turret.rotation = targetRotation * Quaternion.Euler(0f, 270f, 0f);
        
    }


    void AttackEnemy()
    {
        if (currentTarget == null) return;
    
        if (Time.time - lastAttackTime >= 1f / attackRate)
        {
            
            TakeDamage enemy = currentTarget.GetComponent<TakeDamage>();
            if (enemy != null)
            {
                enemy.GetDamage(attackDamage);
            }
            
            lastAttackTime = Time.time;
        }
    }
}
