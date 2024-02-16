using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM01;
    public AudioClip BGM02;

    public bool isInMenu = true;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {    
            DontDestroyOnLoad(this.gameObject);             
    }

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Menu" && !isInMenu)
        {
            isInMenu = true;
            AtMenu();
        }
        else if (sceneName == "level1" || sceneName == "level2" || sceneName == "Level3" || sceneName == "Level4" || sceneName == "Level5"
            || sceneName == "Level6" || sceneName == "Level7" || sceneName == "Level8" || sceneName == "Level9")
        {
            if (isInMenu)
            {
                isInMenu = false;
                AtLevel();
            }
        }
    }


    private void AtMenu()
    {
        audioSource.Stop();
        audioSource.clip = BGM01;
        audioSource.Play();
    }

    private void AtLevel()
    {
        audioSource.Stop();
        audioSource.clip = BGM02;
        audioSource.Play();
    }
}
