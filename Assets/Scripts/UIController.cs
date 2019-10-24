using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject helpScreen;
    public GameObject creditsScreen;

    private void Start()
    {
        helpScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("_Level_Select");
    }
    public void OnHelpButtonClick()
    {
        helpScreen.SetActive(true);
    }
    public void OnCreditsButtonClick()
    {
        creditsScreen.SetActive(true);
    }
    public void OnExitButtonClick()
    {
        helpScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }
    public void OnLevel1ButtonClick()
    {

    }
    public void OnLevel2ButtonClick()
    {

    }
    public void OnLevel3ButtonClick()
    {

    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}