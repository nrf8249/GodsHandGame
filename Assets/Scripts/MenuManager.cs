using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startMenuUI;
    public GameObject gameOverUI;

    [Header("Game Over UI")]
    public TextMeshProUGUI finalScoreText; 

    public static bool showGameOver = false;
    public static int lastScore = 0; 

    void Start()
    {
        if (showGameOver)
        {
            startMenuUI.SetActive(false);
            gameOverUI.SetActive(true);

            if (finalScoreText != null)
            {
                finalScoreText.text = "Final Score: " + lastScore.ToString();
            }
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