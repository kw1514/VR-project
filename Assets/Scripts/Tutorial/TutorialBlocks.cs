using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBlocks : MonoBehaviour
{
    [SerializeField] bool block1Moved = false;
    [SerializeField] bool block2Moved = false;
    [SerializeField] bool block3Moved = false;
    [SerializeField] bool puzzleComplete = false;

    Story story;

    void Start()
    {
        story = FindObjectOfType<Story>();
    }

    void Update()
    {
        if (block1Moved && block2Moved && block3Moved && puzzleComplete == true)
        {
            story.SetTutorialPuzzle2Complete(true);
            puzzleComplete = false;
        }
    }

    public void SelectBlock1()
    {
        block1Moved = true;
        if (block1Moved && block2Moved && block3Moved)
        {
            puzzleComplete = true;
        }
    }

    public void SelectBlock2()
    {
        block2Moved = true;
        if (block1Moved && block2Moved && block3Moved)
        {
            puzzleComplete = true;
        }
    }

    public void SelectBlock3()
    {
        block3Moved = true;
        if (block1Moved && block2Moved && block3Moved)
        {
            puzzleComplete = true;
        }
    }
}
