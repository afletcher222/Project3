using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    public GameObject resultsPanel;
    public PuzzlePieces[] filledPuzzlePieces = new PuzzlePieces[4];
    public float t = 1;
    public Scene scene;
    public Text resultText;
    public int puzzleCounter;

    // Start is called before the first frame update
    void Start()
    {
        resultsPanel.SetActive(false);
        t = 1;
        resultText.text = "";
        puzzleCounter = 0;
        scene = SceneManager.GetActiveScene();
        for (int i = 0; i < filledPuzzlePieces.Length; i++)
        {
            Color c = filledPuzzlePieces[i].puzzleResultUI.color;
            c.a = 0f;
            filledPuzzlePieces[i].puzzleResultUI.color = c;
            filledPuzzlePieces[i].collected = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            resultsPanel.SetActive(true);
            StartCoroutine(PuzzleResult());
        }
    }

    IEnumerator PuzzleResult()
    {
        for (int i = 0; i < filledPuzzlePieces.Length; i++)
        {
            if (filledPuzzlePieces[i].collected == true)
            {
                StartCoroutine(FadeIn(filledPuzzlePieces[i].puzzleResultUI, t));
                t++;
                puzzleCounter++;
            }
        }
        StartCoroutine(WaitForPuzzlePieces(t));
        yield return null;
    }

    IEnumerator FadeIn(Image image, float time)
    {
        yield return new WaitForSeconds(time);

        for (float i = 0.1f; i < 1; i += 0.1f)
        {
            Color c = image.color;
            c.a = (i * 2);
            image.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator WaitForPuzzlePieces(float time)
    {
        yield return new WaitForSeconds(time);
        resultText.text = "You colleded " + puzzleCounter + "/4 puzzle pieces, good job!";
        yield return null;
    }

    public void OnNextLevelButtonClick()
    {
        //For Testing Purposes
        if (scene.name == "SampleScene")
        {
            SceneManager.LoadScene("_Start_Screen");
        }
        //For Testing Purposes

        if (scene.name == "_Level_1")
        {
            SceneManager.LoadScene("_Level_2");
        }
        else if (scene.name == "_Level_2")
        {
            SceneManager.LoadScene("_Level_3");
        }
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("_Start_Screen");
    }

}
