using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.transform.position = checkpoint.transform.position;
            Instantiate(groundPrefab,
                        new Vector3(groundPrefab.transform.position.x + 10,
                                    groundPrefab.transform.position.y,
                                    0),
                        Quaternion.identity);
        }
    }
}
