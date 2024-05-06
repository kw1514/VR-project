using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStory : MonoBehaviour
{
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
    [SerializeField] GameObject tutorialBounds;

    Story story;

    private void Awake() 
    {
        story = this.GetComponent<Story>();  
        if (story == null)
        {
            story = FindObjectOfType<Story>();
        } 
    }

    private void Start() 
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        story.OnTutorialStart();
    }

    private void Update() 
    {
        if(story.tutorialPuzzle1Complete == true) 
        {
            tutorial2.SetActive(true);
            story.OnEnteringSecondTutorial();
            story.SetTutorialPuzzle1Complete(false);
        }    
        else if(story.tutorialPuzzle2Complete == true)
        {
            tutorial3.SetActive(true);
            story.OnEnteringThirdTutorial();
            story.SetTutorialPuzzle2Complete(false);
        }
        else if(story.tutorialPuzzle3Complete == true)
        {
            story.OnFinishingTutorial();
            tutorialBounds.SetActive(false);
            story.SetTutorialComplete(true);
            story.SetTutorialPuzzle3Complete(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player" && this.tag ==  "tutorial1")
        {
           this.GetComponent<BoxCollider>().enabled = false;
           tutorial1.SetActive(true);
           story.OnEnteringTrainingSpace();
        }   
    }
}
