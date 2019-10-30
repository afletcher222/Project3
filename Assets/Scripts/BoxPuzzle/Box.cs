using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Text pickUpText;

    public bool pickedUpBox;
    public bool dontInteract;
    public Transform boxHolder;

    public Box[] boxes;

    public void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && pickedUpBox == true)
        {
            print("worked");
            this.gameObject.transform.SetParent(boxHolder);
            Vector3 position = this.transform.position;
            position.y -= 0.5f;
            this.transform.position = position;
            pickedUpBox = false;
            Invoke("EnablePickUp", 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dontInteract == false)
        {
            if (collision.gameObject.tag == "Player" && pickedUpBox == false)
            {
                pickUpText.text = "Press F to pick up box";
                pickUpText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    this.gameObject.transform.SetParent(collision.gameObject.transform);
                    Vector3 position = this.transform.position;
                    position.y += 0.5f;
                    this.transform.position = position;
                    pickedUpBox = true;
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].dontInteract = true;
                    }

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    public void EnablePickUp()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].dontInteract = false;
        }
    }
}
