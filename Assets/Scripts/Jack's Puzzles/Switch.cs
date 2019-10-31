using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool dontInteract;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SwitchController switchController = gameObject.GetComponent(typeof(SwitchController)) as SwitchController;
                switchController.SwitchState();
            }
        }
    }
}