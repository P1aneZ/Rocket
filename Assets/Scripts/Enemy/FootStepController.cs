using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepController : MonoBehaviour
{
    public AudioClip footstepSound; 
    

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isWalking = false; // Flag to track if the player is walking
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        footstepSound = Resources.Load<AudioClip>("Enemy_Walking_Grass");
    }

    private void Update()
    {
        // Check if the Enemy is walking
        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(footstepSound);
            }                       
        }
    }

    // Call this method when the player starts walking
    public void StartWalking()
    {
        isWalking = true;
    }

    // Call this method when the player stops walking
    public void StopWalking()
    {
        isWalking = false;
    }
}
