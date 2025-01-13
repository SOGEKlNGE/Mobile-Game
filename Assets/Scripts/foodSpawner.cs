using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Array to hold different food prefab sprites
    public GameObject[] foodPrefabs;

    // Time interval between food spawns and speed
    public float spawnCooldown = 0.8f;
    private float spawnTimer;
    public float foodSpeed = 3;

    // Camera reference to get screen boundaries
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
            // Spawn food and reset the timer
            SpawnFood();
            spawnTimer = spawnCooldown;
        }

        // Move the food clones and destroy them if they go out of screen
        DestroyFoodClone();
    }

    void SpawnFood()
    {
        // gets screen boundaries in world coordinates
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // randomly select an X position within the screen bounds
        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        Vector3 spawnPosition = new Vector3(spawnX, screenBounds.y + 1f, 0);

        // choose a random food prefab from the array
        GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        // instantiate the selected food at the spawn position
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);


    }

    void DestroyFoodClone()
    {
        // Get the bottom of the screen in world space
        Vector2 screenBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));

        GameObject[] foodClones = GameObject.FindGameObjectsWithTag("Food");

        // Iterate through each food clone
        foreach (GameObject food in foodClones)
        {
            // Move each food clone downward based on the foodSpeed
            food.transform.Translate(Vector3.down * foodSpeed * Time.deltaTime);

            // If food moves below the screen, destroy it
            if (food.transform.position.y < screenBottom.y - 1f)
            {
                Destroy(food);
            }
        }



    }
}

//References:
// Cyber, C (2021) How To Random Object Spawns in Unity 2D [online] Available at: https://www.youtube.com/watch?v=j6p5Nh7JvmY [Accessed 20 Oct 2024]
