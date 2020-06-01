using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemiesToSpawn;
    public float minRange = 5.1f;
    public float maxRange = 5.4f;
    public int currentAmount = 1;
    public int waveOffset = 1;

    Vector2 RandomPostion()
    {
        Vector3 randPos = Random.onUnitSphere * Random.Range(minRange, maxRange);
        return this.transform.position + randPos;
    }

    public void SpawnEnemies()
    {
        foreach(GameObject enemy in enemiesToSpawn)
        {
            for (int i = 0; i < (currentAmount/waveOffset); i++)
            {
                GameObject temp = Instantiate(enemy, this.transform.parent.parent);
                temp.transform.position = RandomPostion();
            }
        }

        currentAmount += 1;
    }

}
