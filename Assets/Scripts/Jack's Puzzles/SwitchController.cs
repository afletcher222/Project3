using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject RedPlatformHolder;
    public GameObject BluePlatformHolder;

    [SerializeField]
    private bool switchStateRed;
    [SerializeField]
    private bool switchStateBlue;

    void Start()
    {
        switchStateRed = true;
        switchStateBlue = false;
        ActivatePlatforms();
    }
    public void SwitchState()
    {
        if (switchStateRed == true && switchStateBlue == false)
        {
            switchStateRed = false;
            switchStateBlue = true;
        }
        else if (switchStateRed == false && switchStateBlue == true)
        {
            switchStateRed = true;
            switchStateBlue = false;
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