using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerType self;
    public Animator anim;
    [SerializeField]
    private int currentHealth = 100;
    private SpriteRenderer spr;
    public GameObject currentTarget;
    public GameObject projectile;

    private bool readyToFire = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.color = self.color;
        spr.sprite = self.sprite;
        currentHealth = self.health;
        FindNextTarget();
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
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FindNextTarget()
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
                    currentTarget.transform.position) > Vector3.Distance(this.transform.position,
                    target.transform.position))
                {
                    currentTarget = target;
                }
            }
        }

        if (currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Enemy");
        }
        if(anim != null)
        {
            if (currentTarget != null)
            {
                anim.SetBool("hasTarget", true);
            }
            else
            {
                anim.SetBool("hasTarget", false);
            }
        }
    }

    public Quaternion GetDir()
    {
        Vector2 direction = currentTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        return rot;
    }

    void AttackTarget()
    {
        Debug.DrawLine(this.transform.position, currentTarget.transform.position);
        if (readyToFire)
        {
            StartCoroutine(FireProjectile(GetDir()));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyManager>() != null)
        {
            currentHealth -= collision.gameObject.GetComponent<EnemyManager>().self.damage;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator FireProjectile(Quaternion direction)
    {
        GameObject shotProjectile = Instantiate(projectile, this.transform);
        shotProjectile.GetComponent<ProjectileManager>().self = self.projectile;
        shotProjectile.GetComponent<ProjectileManager>().target = currentTarget;
        readyToFire = false;
        yield return new WaitForSeconds(self.attackRate);
        readyToFire = true;
    }
}
