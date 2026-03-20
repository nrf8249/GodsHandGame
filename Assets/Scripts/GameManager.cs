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

    public float energy = 100;
    private float rate = 1;

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

    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        EnergyMaintenance();
        Debug.Log(energy);
    }

    public void GameOver()
    {
        MenuManager.showGameOver = true;

        SceneManager.LoadScene("MenuScene");
    }

    public void SpawnPlatform(InputAction.CallbackContext context)
    {
        if (context.performed && energy > 30) platform = Instantiate(platformPrefab, worldPos, Quaternion.identity);
    }

    public void DespawnPlatform(InputAction.CallbackContext context)
    {
        if (context.canceled) Destroy(platform);
    }

    public void EnergyMaintenance()
    {
        if (platform != null && energy > 0) energy -= rate;
        else if (platform == null && energy <= 100) energy += rate;

        if (energy <= 0) Destroy(platform);
     }
}