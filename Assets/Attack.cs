using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   public float attackRange = 10f;  // Радиус действия турели
    public float attackDamage = 10f; // Урон от атаки
    public float attackRate = 1f;    // Частота атак (время между выстрелами)

    private Transform currentTarget; // Текущий цель (зомби)
    private float lastAttackTime;   // Время последней атаки
    
    private List<GameObject> zombies = new List<GameObject>();

    void Start()
    {
        zombies.AddRange( GameObject.FindGameObjectsWithTag("Zombie"));
    }
    void FixedUpdate()
    {
        FindNearestEnemy();

        if (currentTarget != null)
        {
            RotateTurret();
            AttackEnemy();
        }
    }

    // public void FindNearestEnemy()
    // {
    //     // Находим все объекты с тегом "Zombie"
    //     GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
    //     float closestDistance = Mathf.Infinity;
    //     Transform nearestZombie = null;
    //
    //     foreach (GameObject zombie in zombies)
    //     {
    //         float distance = Vector3.Distance(transform.position, zombie.transform.position);
    //         if (distance < closestDistance && distance <= attackRange)
    //         {
    //             closestDistance = distance;
    //             nearestZombie = zombie.transform;
    //         }
    //     }
    //
    //     currentTarget = nearestZombie;
    // }
    void FindNearestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform nearestZombie = null;

        // Перебираем зомби, которых мы добавили в список
        foreach (GameObject zombie in zombies)
        {
            if (zombie != null)  // Проверка на null
            {
                float distance = Vector3.Distance(transform.position, zombie.transform.position);
                if (distance < closestDistance && distance <= attackRange)
                {
                    closestDistance = distance;
                    nearestZombie = zombie.transform;
                }
            }
        }
        Debug.Log("Zombies in range: " + zombies.Count);
        currentTarget = nearestZombie;
    }


    void RotateTurret()
    {
        if (currentTarget == null) return;

        // Рассчитываем направление к цели
        Vector3 direction = currentTarget.position - transform.position;
        direction.y = 0; // Убираем вертикальную составляющую

        if (direction.magnitude < 0.1f)
        {
            Debug.Log("Target is too close or invalid.");
            return;
        }

        // Рассчитываем целевую ориентацию
        Quaternion lookRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);

        // Плавно поворачиваем турель
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        Debug.Log("Turret rotated towards target.");
    }

    void AttackEnemy()
    {
        if (Time.time - lastAttackTime >= 1f / attackRate)
        {
            // Здесь можно реализовать саму атаку, например, выстрел.
            // Для простоты, добавим просто вывод в консоль, что турель атакует.

            Debug.Log("Turret attacking enemy: " + currentTarget.name);
            // Реализуйте нанесение урона или спавн снарядов
            // currentTarget.GetComponent<Zombie>().TakeDamage(attackDamage);

            lastAttackTime = Time.time;
        }
    }
}

//
// public float attackRange = 10f; 
// private List<Zombie> zombies = new List<Zombie>(); // Список всех зомби
// private Transform currentTarget;
//
// void Start()
// {
//     // Ищем всех зомби на старте
//     zombies.AddRange(FindObjectsOfType<Zombie>());
// }
//
// void Update()
// {
//     // Находим ближайшего зомби
//     FindNearestEnemy();
//
//     if (currentTarget != null)
//     {
//         RotateTurret();
//         AttackEnemy();
//     }
// }
//
// void FindNearestEnemy()
// {
//     float closestDistance = Mathf.Infinity;
//     Transform nearestZombie = null;
//
//     // Перебираем зомби, которых мы добавили в список
//     foreach (Zombie zombie in zombies)
//     {
//         if (zombie != null)  // Проверка на null
//         {
//             float distance = Vector3.Distance(transform.position, zombie.transform.position);
//             if (distance < closestDistance && distance <= attackRange)
//             {
//                 closestDistance = distance;
//                 nearestZombie = zombie.transform;
//             }
//         }
//     }
//
//     currentTarget = nearestZombie;
// }

// void RotateTurret()
// {
//     if (currentTarget == null) return;
//
//     Vector3 direction = currentTarget.position - transform.position;
//     Quaternion lookRotation = Quaternion.LookRotation(direction);
//     transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
// }
//
// void AttackEnemy()
// {
//     // Логика атаки
// }
//
// // Этот метод вызывается, когда новый зомби появляется в сцене
// public void AddZombie(Zombie newZombie)
// {
//     zombies.Add(newZombie);
// }
//
// // Этот метод вызывается, когда зомби уничтожается
// public void RemoveZombie(Zombie zombie)
// {
//     zombies.Remove(zombie);
// }