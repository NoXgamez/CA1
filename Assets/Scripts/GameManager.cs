using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables
    public int maxAllowedEnemies = 20;
    int currentNumberOfEnemies;

    //lets the game know if enemie scan spawn
    public bool CanSpawnEnemy()
    {
        if (currentNumberOfEnemies < maxAllowedEnemies)
            return true;
        else
            return false;
    }

    //when enemy spawns it tells the manager it spawned
    public void RecordEnemySpawned()
    {
        currentNumberOfEnemies++;
    }

    //when enemy dies it tells the manager it died
    public void RecordEnemyDestroyed()
    {
        currentNumberOfEnemies--;
    }
}
