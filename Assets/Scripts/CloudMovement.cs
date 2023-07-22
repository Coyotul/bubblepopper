using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f; 
    public float distance = 5.0f; 

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + Vector3.right * distance; 
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
