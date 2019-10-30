using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Text pickUpText;

    public bool pickedUpBox;
    public bool dontInteract;
    public bool gravity;
    public Transform boxHolder;
    public LayerMask mask;
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
            gravity = true;
            pickedUpBox = false;
            Invoke("EnablePickUp", 1f);
        }
        if (gravity == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, mask);
            print(hit.collider);
            if (hit.collider == null)
            {
                Vector3 position = this.transform.position;
                position.y -= 0.1f;
                this.transform.position = position;
            }
            else if (hit.collider != null)
            {
                gravity = false;
            }
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
