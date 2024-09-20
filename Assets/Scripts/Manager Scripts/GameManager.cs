using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PlaySpecificLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
