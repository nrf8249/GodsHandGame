using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject platformPrefab;
    public GameObject platform;

    private Vector2 mousePos;
    private Vector2 worldPos;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;

        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void GameOver()
    {
        MenuManager.showGameOver = true;

        SceneManager.LoadScene("MenuScene");
    }

    public void SpawnPlatform(InputAction.CallbackContext context)
    {
        if (context.performed) platform = Instantiate(platformPrefab, worldPos, Quaternion.identity);
    }

    public void DespawnPlatform(InputAction.CallbackContext context)
    {
        if (context.canceled) Destroy(platform);
    }
}