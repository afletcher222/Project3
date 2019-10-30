using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonTestScript : MonoBehaviour
{
    public Button CloseButton;
    public GameObject HelpPanel;
    // Start is called before the first frame update
    void Start()
    {
        HelpPanel.SetActive(true);
    }

    // Update is called once per frame
    public void OnCloseButtonClick()
    {
        HelpPanel.SetActive(false);
    }
}
