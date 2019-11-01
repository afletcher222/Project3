using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool dontInteract;
    public SwitchController switchController;

    [SerializeField]
    private bool isColliding = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isColliding)
        {
            switchController.SwitchState();
            isColliding = false;
        }
    }
}