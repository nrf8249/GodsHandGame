using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject ceilingPrefab;
    [SerializeField] private GameObject obstaclePrefab;

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
                        new Vector3(groundPrefab.transform.position.x + 25,
                                    groundPrefab.transform.position.y,
                                    0),
                        Quaternion.identity);
            Instantiate(ceilingPrefab,
                        new Vector3(groundPrefab.transform.position.x + 25,
                                    ceilingPrefab.transform.position.y,
                                    0),
                        Quaternion.identity);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(obstaclePrefab,
                            new Vector3(groundPrefab.transform.position.x + 4.5f + i,
                                        groundPrefab.transform.position.y + 5.33f,
                                        0),
                            Quaternion.identity);
            }
        }
    }
}
