using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager manager;
    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public float spawnTime = 2;

    void Start()
    {
       GameObject go = GameObject.FindGameObjectWithTag("GameController");
        manager = go.GetComponent<GameManager>();

        //repeatedly spawns enemies
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    void SpawnEnemy()
    {
        if(manager.CanSpawnEnemy() == true)
        {
            int enemySpawned = Random.Range(1, 10);
            if (enemySpawned % 2 == 0)
            {
                Instantiate(Enemy2Prefab, transform.position, Quaternion.identity);
                manager.RecordEnemySpawned();
            }
            else
            {
                Instantiate(Enemy1Prefab, transform.position, Quaternion.identity);
                manager.RecordEnemySpawned();
            }
                
        }
    }
}
