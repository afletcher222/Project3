using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButtonScript : MonoBehaviour
{
    
    public void OnMuteButtonClick()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
