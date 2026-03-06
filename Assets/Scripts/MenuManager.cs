using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startMenuUI;
    public GameObject gameOverUI;

    public static bool showGameOver = false;

    void Start()
    {
        if (showGameOver)
        {
            startMenuUI.SetActive(false);
            gameOverUI.SetActive(true);
        }
        else
        {
            startMenuUI.SetActive(true);
            gameOverUI.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        showGameOver = false; 
        SceneManager.LoadScene("GameRunning"); 
    }

    public void RestartGame()
    {
        showGameOver = false; 
        SceneManager.LoadScene("GameRunning");
    }
}