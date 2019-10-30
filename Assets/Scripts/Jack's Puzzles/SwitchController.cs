using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private bool switchStateRed;
    private bool switchStateBlue;

    void Start()
    {
        
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

        }
        else if (switchStateBlue)
        {

        }
    }
}