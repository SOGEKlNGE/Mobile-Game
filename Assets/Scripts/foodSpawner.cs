using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; 
    public float spawnCooldown = 2f; 
    private float spawnTimer; 

    private Camera mainCamera; 

    void Start()
    {
        mainCamera = Camera.main; 
        spawnTimer = spawnCooldown; 
    }

    void Update()
    {
        // Timer code
        spawnTimer -= Time.deltaTime; 
        if (spawnTimer <= 0)
        {
            SpawnFood(); 
            spawnTimer = spawnCooldown; 
        }
    }

    void SpawnFood()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        float spawnX = Random.Range(-screenBounds.x, screenBounds.x); 
        Vector3 spawnPosition = new Vector3(spawnX, screenBounds.y + 1f, 0); 

        GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}

//References:
//https://answers.unity.com/questions/1110965/c-spawn-random-object-at-random-2d-location.html
//https://www.youtube.com/watch?v=hViPCMZeQC4