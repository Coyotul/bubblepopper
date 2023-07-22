using System.Threading.Tasks;
using TMPro;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{

    [SerializeField] private AudioClip[] _audio;
    [SerializeField] private AudioSource _audioSource;
    public float fallSpeed;
    public float rotationSpeed;
    public float swaySpeed;
    public float swayAmount;
    [SerializeField] private ParticleSystem _particleSystem;


    private bool isFalling = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _particleSystem.Stop();
        swaySpeed = Random.Range(swaySpeed, swaySpeed * 1.5f);
        swayAmount = Random.Range(swayAmount, swayAmount * 1.5f);

        rotationSpeed = Random.Range(rotationSpeed, rotationSpeed * 1.5f);
    }

    private void Update()
    {
        if (isFalling)
        {
            // Calculate the sway movement based on time and rotation speed
            float swayOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

            fallSpeed = 1 + (1 - BalloonSpawner.spawnInterval) * 10;
            // Make the balloon fall down (on the Y-axis) with a slow speed
            rb.velocity = new Vector3(0f, -fallSpeed, 0f);

            // Rotate the balloon and add the sway offset
            transform.rotation = Quaternion.Euler(0f, 0f, swayOffset * rotationSpeed);

            // If the balloon has reached a certain height (e.g., -5f), stop it from falling
            if (transform.position.y <= -7f)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private async void OnMouseDown()
    {
        int audio = Random.Range(0, 1);
        if (audio == 0)
            _audioSource.clip = _audio[0];
        else
        {
            _audioSource.clip = _audio[1];
        }
        // Play the particle system for the balloon burst effect
        _particleSystem.Play();
        _audioSource.Play();

        // Wait for a short delay (100 milliseconds)
        await Task.Delay(100);

        // The balloon was touched by the player, so it will burst
        Destroy(gameObject);
        
        ScoreTextController.IncreaseScore();
    }
}