using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.position);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), 0);
    }

}
