using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedCap = 10f;
    //private float gravity = 4.81f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, /*gravity * Time.deltaTime*/ 0, 0));
        if (gameObject.transform.rotation.z != Quaternion.identity.z)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
        if (gameObject.transform.position.y > 15 || gameObject.transform.position.y < 0) PlayerDeath();

        if (speed < speedCap) speed += 0.01f;
    }

    public void PlayerDeath()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }
}
