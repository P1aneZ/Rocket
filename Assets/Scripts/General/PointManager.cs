using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    public float time;
    public float health;
    public float maxHealth;

    public static bool isGamePaused = PauseMenu.GameIsPaused;

    public string sceneName;

    private void Start()
    {
        time = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (GameObject.Find("Rocket_0"))
        {
            health = GameObject.Find("Rocket_0").GetComponent<Character>().currentHealth;
            maxHealth = GameObject.Find("Rocket_0").GetComponent<Character>().maxHealth;
        }

        if (sceneName == "level1" || sceneName == "level2" || sceneName == "Level3" || sceneName == "Level4" || sceneName == "Level5"
            || sceneName == "Level6" || sceneName == "Level7" || sceneName == "Level8" || sceneName == "Level9")
        {
            if (!isGamePaused)
            {
                time += Time.deltaTime;
            }
        }
    }
}
