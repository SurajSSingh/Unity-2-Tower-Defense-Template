using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //public Animator anim;
    public TowerType self;
    [SerializeField]
    private int currentHealth = 100;
    private SpriteRenderer spr;
    public GameObject currentTarget;
    public PlayerBaseScript baseTower;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        baseTower = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>();
        spr = GetComponent<SpriteRenderer>();
        spr.color = self.color;
        spr.sprite = self.sprite;
        currentHealth = self.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            AttackTarget();
        }
        else
        {
            FindNextTarget();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyManager>() != null)
        {
            // Take damage from enemy collision
            ChangeHealth(-collision.gameObject.GetComponent<EnemyManager>().self.damage);
            collision.gameObject.GetComponent<EnemyManager>().ProjectileHit(self.health);
        }
    }

    public float GetTargetDis()
    {
        return (currentTarget.transform.position - transform.position).magnitude;
    }

    public Quaternion GetTargetDir()
    {
        Vector2 direction = currentTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        return rot;
    }

    public void ChangeHealth(int value)
    {
        currentHealth += value;
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void FindNextTarget()
    {
        // Try to find closest enemy

        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            foreach (GameObject target in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (currentTarget == null)
                {
                    currentTarget = target;
                }
                else if (
                Vector3.Distance(this.transform.position,
                                 currentTarget.transform.position)
                > Vector3.Distance(this.transform.position,
                                   target.transform.position))
                {
                    currentTarget = target;
                }
            }
        }
    }

    public void AttackTarget()
    {
        GameObject shotProjectile = CreateProjectile();
    }

    private GameObject CreateProjectile()
    {
        GameObject projectile = new GameObject();
        projectile.transform.parent = this.transform;
        projectile.transform.position = this.transform.position;

        projectile.AddComponent<SpriteRenderer>();
        projectile.AddComponent<CircleCollider2D>();
        projectile.GetComponent<SpriteRenderer>().sortingOrder = 100;
        projectile.GetComponent<CircleCollider2D>().isTrigger = true;

        return projectile;
    }
}
