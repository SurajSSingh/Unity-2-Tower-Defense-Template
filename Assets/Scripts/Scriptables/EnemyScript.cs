using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "CustomObjects/Enemy")]
public class EnemyScript : ScriptableObject
{
    // Overrides the name attribute from ScriptableObject class
    public new string name;

    public float size;
    public int health;
    public int speed;
    public int rotRate;
    public int damage;
    public int score;

    public Color healthyColor;
    public Color damagedColor;
    public Sprite sprite;

    public List<string> targetTags;
}
