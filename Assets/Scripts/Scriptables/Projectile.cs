using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "CustomObjects/Projectile")]
public class Projectile : ScriptableObject
{
    public int damage;
    public float speed;
    public float size;
}
