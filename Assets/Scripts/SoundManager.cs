using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Button unmuteButton;
    public Button muteButton;

    // Start is called before the first frame update
    void Awake()
    {
        muteButton.gameObject.SetActive(true);
        unmuteButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSound()
    {
        audioSource.Pause();
        muteButton.gameObject.SetActive(false);
        unmuteButton.gameObject.SetActive(true);
    }

    public void UnmuteSound()
    {
        audioSource.Play();
        unmuteButton.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(true);
    }
}
