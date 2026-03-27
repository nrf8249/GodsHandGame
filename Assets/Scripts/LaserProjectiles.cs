using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 20;
    private float lifespan = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), 0);
        lifespan -= Time.deltaTime;
        if (lifespan < 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        Player player = collision.collider.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage();
        }
        Destroy(gameObject);

    }
}
