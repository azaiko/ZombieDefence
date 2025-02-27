using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ghoul;
    public GameObject spider;
    public float timeSpawn = 2f;
    public int maxEnemy = 10;
    public float distance = 1f;
    public int spiderCount = 1;
    public int ghoulCount = 1;
    private float _timer;
    public ParticleSystem spawn;

    public static int currentEnemyCount = 0;
    public int wave = 1;
    private bool spidersSpawned = false;
    private bool bossSpawned = false;

    public static bool SpeedUpgrade = false;
    public static bool HealthUpgrade = false;
    private List<GameObject> zombies = new List<GameObject>();

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
        zombies.Clear();
        zombies.AddRange(GameObject.FindGameObjectsWithTag("Zombie"));

        if (currentEnemyCount < maxEnemy)
        {
            spawn.Play();
            Instantiate(enemy, Random.insideUnitSphere * distance + transform.position, Quaternion.identity, transform);
            currentEnemyCount++;
        }
         if (currentEnemyCount == maxEnemy && zombies.Count == 0)
        {
            SpawnUpgrade();
            spidersSpawned = false; // Сбрасываем флаги после перехода на новую волну
            bossSpawned = false;
        }

        if (wave % 5 == 0 && !spidersSpawned)
        {
            SpawnSmallBoss(spiderCount);
            spidersSpawned = true;
            spiderCount += 1;
        }

        if (wave % 10 == 0 && !bossSpawned)
        {
            SpawnBoss(ghoulCount);
            bossSpawned = true;
            ghoulCount += 1;
        }
    }

    void SpawnUpgrade()
    {
        SpeedUpgrade = true;
        HealthUpgrade = true;
        currentEnemyCount = 0;
        maxEnemy += 5;
        timeSpawn -= 0.1f;
        wave++;
        Debug.Log(wave);
    }

    void SpawnSmallBoss(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject spawnSpider =Instantiate(spider, Random.insideUnitSphere * distance + transform.position, Quaternion.identity, transform);
            spawnSpider.transform.Rotate(0f, 180f, 0f);
        }
    }

    void SpawnBoss(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(ghoul, Random.insideUnitSphere * distance + transform.position, Quaternion.identity, transform);
        }
    }
    
}