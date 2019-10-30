using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject RedPlatformHolder;
    public GameObject BluePlatformHolder;

    public bool switchStateRed;
    private bool switchStateBlue;

    void Start()
    {
        switchStateRed = true;
        switchStateBlue = false;
        ActivatePlatforms();
    }
    void Update()
    {

    }
    private void SwitchState()
    {
        if (switchStateRed == true && switchStateBlue == false)
        {
            switchStateRed = false;
            switchStateBlue = true;
        }
        else if (switchStateRed == false && switchStateBlue == true)
        {
            switchStateRed = false;
            switchStateBlue = true;
        }
        ActivatePlatforms();
    }
    private void ActivatePlatforms()
    {
        if (switchStateRed)
        {
            RedPlatformHolder.SetActive(true);
            BluePlatformHolder.SetActive(false);
        }
        else if (switchStateBlue)
        {
            RedPlatformHolder.SetActive(false);
            BluePlatformHolder.SetActive(true);
        }
    }
}