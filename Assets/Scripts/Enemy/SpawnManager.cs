using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private int wave = 0;

    public List<EnemySpawner> spawnPoints = new List<EnemySpawner>();
    public TextMeshProUGUI waveText;

    public void SpawnNewWave()
    {
        waveText.text = $"WAVE: {++wave}";
        foreach (EnemySpawner spawner in spawnPoints)
        {
            spawner.SpawnEnemies();
        }
    }
}
