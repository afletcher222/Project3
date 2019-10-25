using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePickUps : PickUps
{
    public PuzzlePieces puzzle;

    private void Start()
    {
        puzzle = GetComponent<PuzzlePieces>();
    }

    public override void OnPickUp(Transform item)
    {
        puzzle.puzzleUI.color = new Color32(255, 255, 255, 255);
        puzzle.puzzlePickUp.gameObject.SetActive(false);
    }
}
