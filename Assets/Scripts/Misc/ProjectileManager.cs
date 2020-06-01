using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public Projectile proj;
    public Vector3 direction;
    private bool launched = false;
    private float deathTimer = 10f;

    private void Start()
    {
        transform.localScale *= proj.size;
        gameObject.GetComponent<SpriteRenderer>().color = proj.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != null && !launched)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * proj.speed, ForceMode2D.Impulse);
            launched = true;
        }
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDir(Vector3 dir)
    {
        direction = dir;
    }
}
