using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit an obstacle!");
            collision.gameObject.GetComponent<Player>().PlayerDeath();
            // You can add additional logic here, such as reducing player health or triggering a game over.
        }
    }
}
