using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] balloonPrefabs; // List of balloon prefabs (the four types of balloons)
    public Transform[] spawnPoints; // List of spawn points (the four empty objects)
    public static float spawnInterval = 1f; // Time interval between spawning balloons in seconds
    private static bool _canSpawn = true;
    
    private GameObject[] balloons;

    private GameObject currentBalloon;
    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.time;
        spawnInterval = 1f;
    }

    private void Update()
    {
        // Check if enough time has passed since the last balloon was spawned
        if (Time.time - lastSpawnTime >= spawnInterval && _canSpawn)
        {
            // Spawn a random balloon
            SpawnRandomBalloon();

            // Update the last spawn time to the current time
            lastSpawnTime = Time.time;
        }

        // Dificulty changes
        if (spawnInterval > 0.1)
        {
            spawnInterval -= 0.00003f;
        }
        Debug.Log(spawnInterval);
        
        
    }

    public static void StartSpawning()
    {
        _canSpawn = true;
    }

    public static void StopSpawning()
    {
        _canSpawn = false;
    }
    

    private void SpawnRandomBalloon()
    {
        // Choose a random index from the balloon prefabs list
        int randomIndex = Random.Range(0, balloonPrefabs.Length);

        // Choose a random spawn point from the spawn points list
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

        // Spawn the chosen balloon at the chosen spawn point
        currentBalloon = Instantiate(balloonPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}