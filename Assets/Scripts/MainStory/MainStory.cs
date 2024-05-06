using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStory : MonoBehaviour
{
    [SerializeField] public bool startHintTimer = false;
    [SerializeField] float hintTimer = 0;
    [SerializeField] float hintDelay;

    Story story;

    private void Awake()
    {
        story = this.GetComponent<Story>();
    }

    void Start()
    {
        if (story != null)
        {
            story.OnGameLoad();
        }
        else if (story == null)
        {
            story = FindObjectOfType<Story>();
        }
    }

    private void Update()
    {
        if (startHintTimer == true)
        {
            hintTimer++;


            if (hintTimer >= hintDelay)
            {
                float randomNumber = Random.Range(0, 2);
                if (randomNumber == 1)
                {
                    story.Puzzle1Hint1();
                }
                else if (randomNumber == 0)
                {
                    story.Puzzle1Hint2();
                }

                hintTimer = 0;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "puzzle1" && other.tag == "Player")
        {
            story.OnApproachingPuzzle1();
            StartHintTimer();
        }
    }

    private void StartHintTimer()
    {
        startHintTimer = true;
    }
}
