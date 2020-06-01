using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;
    public Text winText;
    public Text loseText;
    public List<GameObject> enemyBases;
    public GameObject playerBase;
    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
        loseText.enabled = false;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase == null)
        {
            endScreen.SetActive(true);
            loseText.enabled = true;
        }
        else if (enemyBases.Count == 0)
        {
            endScreen.SetActive(true);
            winText.enabled = true;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
