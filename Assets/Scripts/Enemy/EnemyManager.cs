using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyScript self;
    public Animator anim;
    [SerializeField]
    private int currentHealth;
    private SpriteRenderer spr;
    private int healthyLevelHealth = 60;
    public GameObject currentTarget;

    private float baseSize = 4;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = self.health;
        spr.sprite = self.sprite;
        spr.color = self.healthyColor;
        this.transform.localScale *= (baseSize * self.size);
        //FindNextTarget();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    UpdateDistance();
    //}

    void UpdateSprite()
    {
        // Changes Sprite color
        if (currentHealth >= healthyLevelHealth)
        {
            spr.color = self.healthyColor;
        }
        else
        {
            spr.color = self.damagedColor;
        }
    }

    public Quaternion GetDir()
    {
        Vector2 direction = currentTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        return rot;
    }

    //void UpdateDistance()
    //{
    //    if (anim.GetBool("hasTarget"))
    //    {
    //        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
    //        anim.SetFloat("distanceToTarget", distance);
    //    }
    //    else
    //    {
    //        FindNextTarget();
    //    }
    //}

    //void FindNextTarget()
    //{
    //    foreach (string objTag in self.targetTags)
    //    {
    //        if (GameObject.FindGameObjectsWithTag(objTag).Length != 0)
    //        {
    //            currentTarget = GameObject.FindGameObjectsWithTag(objTag)[0];
    //        }
    //    }

    //    if (currentTarget == null)
    //    {
    //        currentTarget = GameObject.FindGameObjectWithTag("Player");
    //    }
    //    if (currentTarget != null)
    //    {
    //        anim.SetBool("hasTarget", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("hasTarget", false);
    //    }
    //}

    public void ProjectileHit(int value)
    {
        currentHealth -= value;
        UpdateSprite();
        if (currentHealth <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseScript>().AddResourcesToPlayer(self.score);
            Destroy(this.gameObject);
        }
    }
}
