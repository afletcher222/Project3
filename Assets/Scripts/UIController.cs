using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("_Level_Select");
    }
    public void OnHelpButtonClick()
    {

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
        Application.Quit()
    }
}