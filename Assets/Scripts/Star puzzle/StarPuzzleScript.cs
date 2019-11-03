using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPuzzleScript : MonoBehaviour
{
    public StarBlock[] blocks;
    public GameObject[] lines;

    public GameObject lastPlatform;

    public bool canCollide;

    void Start()
    {
        lastPlatform.SetActive(false);
        canCollide = true;

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(false);
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].active = false;
        }
    }

    public void Update()
    {
        if(blocks[0].active == true && blocks[1].active == true && blocks[2].active == true && blocks[3].active == true && blocks[4].active == true && blocks[5].active == true && blocks[6].active == true)
        {
            lastPlatform.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Piece1" && canCollide)
        {

            blocks[0].active = true;
            lines[0].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece2" && canCollide)
        {

            blocks[1].active = true;
            lines[1].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece3" && canCollide)
        {

            blocks[2].active = true;
            lines[2].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece4" && canCollide)
        {

            blocks[3].active = true;
            lines[3].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece5" && canCollide)
        {
            blocks[4].active = true;
            lines[4].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece6" && canCollide)
        {
            blocks[5].active = true;
            lines[5].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }

        else if (collision.gameObject.name == "Piece7" && canCollide)
        {
            blocks[6].active = true;
            lines[6].SetActive(true);
            canCollide = false;
            Invoke("AllowedToCollide", 1f);
        }
    }

    public void AllowedToCollide()
    {
        canCollide = true;
    }

    public void LastPlatformActive()
    {
        lastPlatform.SetActive(true);
    }
}
