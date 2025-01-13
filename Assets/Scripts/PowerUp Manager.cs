using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public Button powerUpButton;
    public FoodSpawner foodspawner;
    public GemManager gemmanager;

    public bool powerupActive = false;
    private bool waitingForShake = false;

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
        if (gemmanager.gems >= 20)
        {
            powerUpButton.gameObject.SetActive(true);
        }

        else
        {
            powerUpButton.gameObject.SetActive(false);
        }

        if (waitingForShake)
        {
            Debug.LogWarning("Input Shake:" + Input.acceleration.magnitude);

            if (Input.acceleration.magnitude > 2.1f)
            {
                foodspawner.spawnCooldown = 0.1f;
                Debug.LogWarning("Food Cooldown Reduced: " + foodspawner.spawnCooldown);

                shakeTimer = shakeDuration;
                waitingForShake = false;
            }
        }

        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                foodspawner.spawnCooldown = 0.8f;
                Debug.LogWarning("Food Cooldown Reverted: " + foodspawner.spawnCooldown);
            }
        }

        Debug.LogWarning("Gems:" + gemmanager.gems);
        Debug.LogWarning("Food Spawner Cooldown: " + foodspawner.spawnCooldown);

    }

    public void ActivatePowerUp()
    {
        if (gemmanager.gems >= 20)
        {
            gemmanager.gems -= 10;
            powerupActive = true;
            gemmanager.UpdateGemUI();
            waitingForShake = true;
            powerUpButton.gameObject.SetActive(false);
        }

    }
}
