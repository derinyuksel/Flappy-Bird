using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    // Array of cloud prefabs to choose from (set these in the Inspector)
    public GameObject[] Clouds;

    // Time (in seconds) between each cloud spawn
    public float spawnRate = 9;

    // Timer to track how much time has passed since the last spawn
    private float timer = 0;

    // How far up or down the cloud can randomly spawn from this object's Y position
    public float heightOffset = 7;

    // Called when the game starts
    void Start()
    {
        // Spawn one cloud immediately at the start
        SpawnCloud();
    }

    // Called every frame
    void Update()
    {
        // Add the time passed since last frame to the timer
        timer += Time.deltaTime;

        // If enough time has passed (based on spawnRate), spawn a new cloud
        if (timer >= spawnRate)
        {
            SpawnCloud();    // Spawn the cloud
            timer = 0;      // Reset the timer
        }
    }

    // Handles the actual cloud spawning logic
    void SpawnCloud()
    {
        // Calculate the minimum Y position for cloud spawn
        float minY = transform.position.y - heightOffset;

        // Calculate the maximum Y position for cloud spawn
        float maxY = transform.position.y + heightOffset;

        // Pick a random Y position between minY and maxY
        float randomY = Random.Range(minY, maxY);

        // Pick a random cloud prefab from the array
        int index = Random.Range(0, Clouds.Length);

        // Set the cloud's spawn position using this object's X, the random Y, and Z = 0
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);

        // Create the cloud in the scene at the spawn position, with no rotation
        Instantiate(Clouds[index], spawnPos, Quaternion.identity);
    }
}
