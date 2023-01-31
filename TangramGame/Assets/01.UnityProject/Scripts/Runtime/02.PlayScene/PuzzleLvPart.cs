using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLvPart : MonoBehaviour
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;
    

    // Start is called before the first frame update
    void Start()
    {
        //puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
        puzzleImage = gameObject.
            FindChildObj("PuzzleLvImage").GetComponentMust<Image>();
        switch(puzzleImage.sprite.name)
        {
            case "Puzzle_BigTriangle1":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            case "Puzzle_BigTriangle2":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            default:
                puzzleType = PuzzleType.NONE;
                break;
        }       // switch()
    }       // Start()

    // Update is called once per frame
    void Update()
    {
        
    }
}
