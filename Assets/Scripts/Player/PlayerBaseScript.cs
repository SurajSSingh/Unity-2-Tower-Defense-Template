using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBaseScript : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerResourcesText;
    public GameObject gameOverField;
    public GameObject cursor;
    public GameObject towerTemplate;

    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private int resources = 100;
    private float resourseCoolDown = 1f;
    private float timerCoolDown;
    private int resourcesIncrease = 10;
    [SerializeField]
    private int currentUnit = 0;
    // public List<"Units"> unitList;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + health.ToString();
        playerResourcesText.text = "Money: " + resources.ToString();
        if (timerCoolDown <= 0f)
        {
            timerCoolDown = resourseCoolDown;
            resources += resourcesIncrease;
        }
        else
        {
            timerCoolDown -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Time.timeScale = 0.0f;
            gameOverField.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && cursor.active)
        {
            BuyTower(cursor.transform.position);
            cursor.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyManager>() != null)
        {
            health -= collision.gameObject.GetComponent<EnemyManager>().self.damage;
            Destroy(collision.gameObject);
        }
    }

    public void BuyTower(Vector3 location)
    {
        // Spawn the units using selection, make sure to add cost
        Instantiate(towerTemplate, location, Quaternion.identity);
    }

    public void SelectTowerToBuy(int currentSelection)
    {
        currentUnit = currentSelection;
    }
}
