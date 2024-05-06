using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinishTutorial : MonoBehaviour
{
   Story story;
   LevelManager levelManager;

    void Start()
    {
        story = FindObjectOfType<Story>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (story.tutorialComplete == true)
        {
            this.GetComponent<XRSimpleInteractable>().enabled = true;
            story.SetTutorialComplete(false);
        }
    }

    public void OnSelect()
    {
        levelManager.LoadGame();
    }
}
