using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public EnemyScript self;
    public Animator anim;
    [SerializeField]
    private int currentHealth;
    private SpriteRenderer spr;
    private int healthyLevelHealth = 60;
    public GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        currentHealth = self.health;
        FindNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
        if (currentTarget != null)
        {
            AttackTarget();
        }
        else
        {
            FindNextTarget();
        }
        
    }

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

    void FindNextTarget()
    {
        foreach (string objTag in self.targetTags)
        {
            if (GameObject.FindGameObjectsWithTag(objTag).Length != 0)
            {
                currentTarget = GameObject.FindGameObjectsWithTag(objTag)[0];
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

    }
}
