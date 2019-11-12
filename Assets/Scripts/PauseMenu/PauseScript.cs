using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject hintMenu;

    // Start is called before the first frame update
    void Start()
    {
        hintMenu.SetActive(false);
    }

    public void OnHintButtonClick()
    {
        hintMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnHintButtonCloseClick()
    {
        Time.timeScale = 1;
        hintMenu.SetActive(false);
    }
}
