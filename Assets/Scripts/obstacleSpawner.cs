using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float obstacleCooldown = 2f;
    private float obstacleTimer;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        obstacleTimer = obstacleCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        // Timer code
        obstacleTimer -= Time.deltaTime;
        if (obstacleTimer <= 0)
        {
            SpawnObstacle();
            obstacleTimer = obstacleCooldown;
        }
    }

    void SpawnObstacle()
    {
        // gets screen boundaries in world coordinates
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // randomly select an X position within the screen bounds
        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        Vector3 spawnPosition = new Vector3(spawnX, screenBounds.y + 1f, 0);

        // choose a random food prefab from the array
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // instantiate the selected food at the spawn position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

    }
}
