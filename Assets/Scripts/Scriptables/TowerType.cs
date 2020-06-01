using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "CustomObjects/Tower")]
public class TowerType : ScriptableObject
{
    public string TowerName;
    public int cost;
    public int health;
    public float attackRate;
    public Color color = Color.gray;
    public Sprite sprite;

    public Projectile projectile;
}
