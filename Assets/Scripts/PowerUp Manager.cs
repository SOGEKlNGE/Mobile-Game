using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public Button powerUpButton;
    public FoodSpawner foodspawner;
    public GemManager gemmanager;

    // Flags to track power-up activation and waiting for user shake input
    public bool powerupActive = false;
    private bool waitingForShake = false;

    // Timers for managing the shake duration and cooldown reset
    private float shakeTimer = 0f;
    private float shakeDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        powerUpButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Show the power-up button if the player has at least 20 gems
        if (gemmanager.gems >= 20)
        {
            powerUpButton.gameObject.SetActive(true);
        }

        else
        {
            powerUpButton.gameObject.SetActive(false);
        }

        // If waiting for the player to shake the device
        if (waitingForShake)
        {
            Debug.LogWarning("Input Shake:" + Input.acceleration.magnitude);

            // Check if the device shake exceeds the threshold
            if (Input.acceleration.magnitude > 2.1f)
            {
                // Reduce the spawn cooldown for the food spawner
                foodspawner.spawnCooldown = 0.1f;
                Debug.LogWarning("Food Cooldown Reduced: " + foodspawner.spawnCooldown);

                // Start the timer for the power-up duration
                shakeTimer = shakeDuration;
                waitingForShake = false;
            }
        }

        // Manage the power-up timer
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;

            // When the timer runs out, revert the spawn cooldown to its default value
            if (shakeTimer <= 0f)
            {
                foodspawner.spawnCooldown = 0.8f;
                Debug.LogWarning("Food Cooldown Reverted: " + foodspawner.spawnCooldown);
            }
        }

        // Debug logs for testing
        Debug.LogWarning("Gems:" + gemmanager.gems);
        Debug.LogWarning("Food Spawner Cooldown: " + foodspawner.spawnCooldown);

    }

    public void ActivatePowerUp()
    {
        // Activate the power-up only if the player has enough gems
        if (gemmanager.gems >= 20)
        {
            // Deduct gems for activating the power-up
            gemmanager.gems -= 10;
            powerupActive = true;

            // Update the UI to reflect the new gem count
            gemmanager.UpdateGemUI();

            // Set the flag to wait for the user to shake the device
            waitingForShake = true;

            // Hide the power-up button during the power-up process
            powerUpButton.gameObject.SetActive(false);
        }

    }
}
