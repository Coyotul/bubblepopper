using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f; // Viteza de deplasare a norului
    public float distance = 5.0f; // Distanța pe care o va parcurge norul

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + Vector3.right * distance; // Mișcarea pe axa X, poți schimba Vector3.right cu Vector3.forward pentru mișcare pe axa Z
    }

    void Update()
    {
        // Calculează mișcarea interpolată
        float step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, targetPosition, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
