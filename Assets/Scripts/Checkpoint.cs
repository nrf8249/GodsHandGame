using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject ceilingPrefab;
    [SerializeField] private List<GameObject> obstaclePrefabs;

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
                        new Vector3(groundPrefab.transform.position.x + groundPrefab.transform.localScale.x,
                                    groundPrefab.transform.position.y,
                                    0),
                        Quaternion.identity);
            Instantiate(ceilingPrefab,
                        new Vector3(groundPrefab.transform.position.x + groundPrefab.transform.localScale.x,
                                    ceilingPrefab.transform.position.y,
                                    0),
                        Quaternion.identity);
            int randomNum = Random.Range(0, obstaclePrefabs.Count);
            {
                Instantiate(obstaclePrefabs[randomNum],
                            new Vector3(groundPrefab.transform.position.x + groundPrefab.transform.localScale.x + 10,
                                        obstaclePrefabs[randomNum].transform.position.y,
                                        0),
                            Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
