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
}