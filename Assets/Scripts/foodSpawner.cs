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

    

}

//References:
// Cyber, C (2021) How To Random Object Spawns in Unity 2D [online] Available at: https://www.youtube.com/watch?v=j6p5Nh7JvmY [Accessed 20 Oct 2024]
