using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class canvasManager : MonoBehaviour
{
    public GameObject fadingPanel;
    public GameObject pauseMenu;
    public GameObject buildingCursor;

    private void Start()
    {
        fadingPanel.SetActive(false);
        PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ResetLevel()
    {

        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex));
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ActivateCursor()
    {
        buildingCursor.SetActive(true);
    }

    IEnumerator FadeEffect(int sceneNumber)
    {
        fadingPanel.SetActive(true);
        for(int i = 0; i < 100; i++)
        {
            fadingPanel.GetComponent<CanvasGroup>().alpha = (float)(i*0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
        }

        SceneManager.LoadScene(sceneNumber);
    }
}
