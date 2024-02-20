using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepController : MonoBehaviour
{
    public AudioClip footstepSound;


    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isWalking = false; // Flag to track if the player is walking
    public bool isAround = false;

    public Vector3 target;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        footstepSound = Resources.Load<AudioClip>("Enemy_Walking_Grass");
    }

    private void Update()
    {
        // Check if the Enemy is walking
        if (isWalking && isAround)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(footstepSound);
            }
        }
    }


    private void FixedUpdate()
    {
        if (GameObject.Find("Rocket_0"))
            target = GameObject.Find("Rocket_0").GetComponent<Transform>().position;//获取目标的位置
        Vector2 position = transform.position;
        if (Mathf.Abs(gameObject.transform.position.x - target.x) <= 30 && Mathf.Abs(gameObject.transform.position.y - target.y) <= 30)
        {
            isAround = true;
        }
        else
        {
            isAround = false;
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
