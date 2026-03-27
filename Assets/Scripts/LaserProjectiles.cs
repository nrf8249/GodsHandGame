using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player")
        {
            // TODO - Make player lose a life

        }
        Destroy(gameObject);

    }
}
