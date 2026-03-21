using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) gameObject.transform.position = new Vector3(target.position.x + 4.5f, 4.5f, gameObject.transform.position.z);
    }
}
