using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject deathScreen;


    public Scene scene;

    void Start()
    {
        winScreen.SetActive(false);
        deathScreen.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

    public void OnNextLevelButtonClick()
    {
        if (SceneManager.GetActiveScene().name == "_Level_1")
        {
            SceneManager.LoadScene("_Level_2");
        }
        else if (SceneManager.GetActiveScene().name == "_Level_2")
        {
            SceneManager.LoadScene("_Level_3");
        }
        else
        {
            SceneManager.LoadScene("_Level_Select");
        }
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("_Start_Screen");
    }

    public void Death()
    {
        deathScreen.SetActive(true);
    }

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene(scene.name);
    }
}