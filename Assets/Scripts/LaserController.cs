using Unity.VisualScripting;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnProjectile), 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProjectile()
    {
        Instantiate(bullet,
                    new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), 
                    Quaternion.identity);
}
}
