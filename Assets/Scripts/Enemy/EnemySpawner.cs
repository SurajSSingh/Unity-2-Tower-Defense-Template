using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public RuntimeAnimatorController enemyAC;
    public List<EnemyScript> enemyTypes = new List<EnemyScript>();
    public float minRange = 5.1f;
    public float maxRange = 5.4f;
    public int currentAmount = 1;
    public int waveOffset = 1;

    Vector2 RandomPostion()
    {
        Vector3 randPos = Random.onUnitSphere * Random.Range(minRange, maxRange);
        return this.transform.position + randPos;
    }

    EnemyScript RandomEnemyType()
    {
        return enemyTypes[Random.Range(0, enemyTypes.Count)];
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < (currentAmount / waveOffset); i++)
        {
            GameObject temp = CreateEnemy(RandomEnemyType());
            temp.transform.position = RandomPostion();
        }

        currentAmount += 1;
    }

    GameObject CreateEnemy(EnemyScript enemy)
    {
        GameObject go = new GameObject(enemy.name + " (Clone)");
        go.transform.parent = this.transform.parent.parent;
        go.tag = "Enemy";

        go.AddComponent<Animator>();
        go.GetComponent<Animator>().runtimeAnimatorController = enemyAC;

        go.AddComponent<SpriteRenderer>();
        go.AddComponent<EnemyManager>();
        go.GetComponent<EnemyManager>().self = enemy;


        go.AddComponent<CircleCollider2D>();
        go.AddComponent<Rigidbody2D>();
        go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        go.GetComponent<Rigidbody2D>().simulated = true;
        go.GetComponent<Rigidbody2D>().gravityScale = 0;

        return go;
    }

}
