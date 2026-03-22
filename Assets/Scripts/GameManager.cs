using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject player;
    public GameObject platform;

    private Vector2 mousePos;
    private Vector2 worldPos;

    public float energy = 100;
    
    private float rate = 20f; // Amount of energy to lose per second

    public float pointTotal = 0;
    private float lastXPos = 0;
    private float currentXPos;

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

        EnergyMaintenance(Time.deltaTime);
        PointMaintenance(false);
        Debug.Log(energy + "\t-\t "  + pointTotal);
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

    public void EnergyMaintenance(float deltaTime)
    {
        if (platform != null && energy > 0) energy -= (rate * deltaTime);
        else if (platform == null && energy <= 100) energy += (rate * deltaTime);

        if (energy <= 0) Destroy(platform);
    }

    public void PointMaintenance(bool coinCollected)
    {
        currentXPos = player.transform.position.x;
        if (currentXPos > lastXPos) pointTotal += currentXPos - lastXPos;
        lastXPos = currentXPos;

        if (coinCollected) pointTotal += 20;
    }
}