using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 10f;  // Радиус действия турели
    public float attackDamage = 10f; // Урон от атаки
    public float attackRate = 1f;    // Частота атак (время между выстрелами)

    private Transform currentTarget; // Текущая цель (зомби)
    private float lastAttackTime;    // Время последней атаки
    private List<GameObject> zombies = new List<GameObject>();

    void Start()
    {
        UpdateZombieList();
    }

    void FixedUpdate()
    {
        UpdateZombieList(); // Обновляем список зомби, если их количество изменилось
        FindNearestEnemy();

        if (currentTarget != null)
        {
            RotateTurret();
            //AttackEnemy();
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
            if (zombie != null) // Проверка на null
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
        direction.y = 0;

        if (direction.magnitude < 0.1f)
        {
            Debug.LogWarning("Target is too close or invalid for rotation.");
            return;
        }

        // Рассчитываем целевую ориентацию (только горизонтально)
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Плавно поворачиваем турель
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

        Debug.Log($"Turret rotating towards {currentTarget.name}");
    }
    // void RotateTurret()
    // {
    //     if (currentTarget == null) return;
    //
    //     // Рассчитываем направление к цели
    //     Vector3 direction = currentTarget.position - transform.position;
    //     direction.y = 0; // Убираем вертикальную составляющую
    //
    //     if (direction.magnitude < 0.1f)
    //     {
    //         Debug.LogWarning("Target is too close or invalid.");
    //         return;
    //     }
    //
    //     // Рассчитываем целевую ориентацию
    //     Quaternion targetRotation = Quaternion.LookRotation(direction);
    //
    //     // Плавно поворачиваем турель
    //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    // }

    // void AttackEnemy()
    // {
    //     if (currentTarget == null) return;
    //
    //     if (Time.time - lastAttackTime >= 1f / attackRate)
    //     {
    //         Debug.Log($"Turret attacking enemy: {currentTarget.name} with damage {attackDamage}");
    //
    //         // Реализуйте нанесение урона врагу
    //         Zombie zombie = currentTarget.GetComponent<Zombie>();
    //         if (zombie != null)
    //         {
    //             zombie.TakeDamage(attackDamage);
    //         }
    //
    //         lastAttackTime = Time.time;
    //     }
    // }
}
