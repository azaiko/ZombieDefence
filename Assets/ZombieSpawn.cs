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

    public static int currentEnemyCount = 0;  

    void Start()
    {
        _timer = timeSpawn;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Spawner();
        }
    }

    void Spawner()
    {
        _timer = timeSpawn;

        if (currentEnemyCount < maxEnemy)
        {
                
            spawn.Play();
            Instantiate(enemy, Random.insideUnitSphere * distance + transform.position, Quaternion.identity, transform);
            currentEnemyCount++;  
        }
        else if(currentEnemyCount == maxEnemy && Attack.zombies.Count == 0)
        {
                
            SpawnUpgrade();
        }
    }

    void SpawnUpgrade()
    {
        currentEnemyCount = 0;
        maxEnemy += 5;
        timeSpawn -= 0.1f;
    }
    
}