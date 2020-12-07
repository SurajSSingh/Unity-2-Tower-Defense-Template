using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "CustomObjects/Tower")]
public class TowerType : ScriptableObject
{
    public string towerName;

    public int cost;
    public int health;

    public Sprite sprite;
    public Color color = Color.gray;

    public float attackCooldown;
    public float attackRange;
    public float rotationOffset=0;

    public ProjectileType projectile;
}
