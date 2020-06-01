using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<EnemySpawner> spawnPoints = new List<EnemySpawner>();

    public void SpawnNewWave()
    {
        foreach(EnemySpawner spawner in spawnPoints)
        {
            spawner.SpawnEnemies();
        }
    }
}
