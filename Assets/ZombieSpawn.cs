using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject enemy;
    public float timeSpawn = 2f;
    public int maxEnemy = 10;
    public float distance = 1f;
    private float _timer;
    public ParticleSystem spawn;

    private int currentEnemyCount = 0;  // Счётчик заспавненных зомби

    void Start()
    {
        _timer = timeSpawn;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = timeSpawn;

            if (currentEnemyCount < maxEnemy)
            {
                // Если количество зомби меньше максимального, спавним нового
                spawn.Play();
                Instantiate(enemy, Random.insideUnitSphere * distance + transform.position, Quaternion.identity, transform);
                currentEnemyCount++;  // Увеличиваем счётчик заспавненных зомби
            }
            else
            {
                // Если заспавнено максимально возможное количество, ставим анимацию на паузу
                spawn.Pause();
            }
        }
    }

    // Вы можете вызвать этот метод, чтобы уменьшить количество зомби (например, при их уничтожении)
    public void OnZombieDeath()
    {
        currentEnemyCount--;  // Уменьшаем счётчик при смерти зомби
        if (currentEnemyCount < maxEnemy)
        {
            // Если количество зомби меньше максимума, возобновляем анимацию
            spawn.Play();
        }
    }
}