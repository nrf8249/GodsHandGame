using Unity.VisualScripting;
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
        Vector3 endPos = new Vector3(target.position.x + 4.5f, 4.5f, gameObject.transform.position.z);
        if (target != null) gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPos, 1);
    }
}
