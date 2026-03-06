using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : MonoBehaviour
{
    [SerializeField] public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = worldPos;

    }
}
