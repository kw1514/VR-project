using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    [Header("PopUp")]
    [SerializeField] GameObject popUp;
    [SerializeField] TextMeshProUGUI popUpText;

    [Header("Delays")]
    [SerializeField] float delay1 = 2f;
    [SerializeField] float delay2 = 5f;
    [SerializeField] float turnOffDelay = 10f;


    [HideInInspector] public bool tutorialPuzzle1Complete = false;
    [HideInInspector] public bool tutorialPuzzle2Complete = false;
    [HideInInspector] public bool tutorialPuzzle3Complete = false;
    [HideInInspector] public bool tutorialComplete = false;

    AudioPlayer audioPlayer;

    private void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void OnTutorialStart()
    {
        SetPopUp("Hello, I am Exo. Your helpful AI to guide you along your dangerous quests.");
        StartCoroutine(ChangeText(delay1, "Let’s start with some basics."));
        StartCoroutine(ChangeText(delay2, "Try moving forward with the left controller into the training space."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnEnteringTrainingSpace()
    {
        SetPopUp("Congratulations! You made it.");
        StartCoroutine(ChangeText(delay1, "On your adventures sometimes things will need to be activated with a power source."));
        StartCoroutine(ChangeText(delay2, "Try this now by carrying the power cube over to the inactive larger cube."));
    }

    public void OnEnteringSecondTutorial()
    {
        SetPopUp("Great Job!");
        StartCoroutine(ChangeText(delay1, "Sometimes there will be debris blocking the way."));
        StartCoroutine(ChangeText(delay2, "Practice moving these blocks now."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnEnteringThirdTutorial()
    {
        SetPopUp("Awesome job! You are almost ready.");
        StartCoroutine(ChangeText(delay1, "Another way to activate objects is to select them."));
        StartCoroutine(ChangeText(delay2, "Try activating the symbol."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnFinishingTutorial()
    {
       SetPopUp("Great job! I think you are ready for your adventure.");
        StartCoroutine(ChangeText(delay1, "Feel free to explore if you need more time."));
        StartCoroutine(ChangeText(delay2, "If you are ready for your next adventure to begin select your ship."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnGameLoad()
    {
        SetPopUp("Hello, it’s me Exo again.");
        StartCoroutine(ChangeText(delay1, "We made it to Tarn-Vedra the legendary home planet of the Vedran race."));
        StartCoroutine(ChangeText(delay2, "It is rumored that there is a powerful object hidden somewhere. Good luck finding it!"));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnApproachingPuzzle1()
    {
        SetPopUp("It looks like the door is closed and there is no doorknob in sight. ");
        StartCoroutine(ChangeText(delay1, "Typical Vedrans! There must be some other way to open this door."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnExitingPuzzle1()
    {
        SetPopUp("Great Job!");
        StartCoroutine(ChangeText(delay1, "Now let's see what secrets the Vedrans hold here."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void Puzzle1Hint1()
    {
        SetPopUp("It looks like the guard statue is inactive.");
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void Puzzle1Hint2()
    {
        SetPopUp("Try to find a power source for the statue.");
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnFinalPuzzleWrongOrder()
    {
        SetPopUp("That doesn't seem to be right.");
        StartCoroutine(ChangeText(delay1, "Look around and see if you can find the right order."));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnSolvingFinalPuzzle()
    {
        SetPopUp("Nicely done!");
        StartCoroutine(ChangeText(delay1, "You found the legendary sword Wave Rider! With this you can travel all of time and space!"));
        StartCoroutine(ChangeText(delay2, "Try picking it up and using it to travel somewhere new!"));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }

    public void OnPickingSword()
    {
        SetPopUp("You did it!");
        StartCoroutine(ChangeText(delay1, "You created a rip in the very fabric of time and space."));
        StartCoroutine(ChangeText(delay2, "If you are ready for your adventure to continue, enter the rip!"));
        StartCoroutine(DisableWithTimer(turnOffDelay));
    }


    public void SetTutorialPuzzle1Complete(bool set)
    {
        tutorialPuzzle1Complete = set;
    }

    public void SetTutorialPuzzle2Complete (bool set)
    {
        tutorialPuzzle2Complete = set;
    }

    public void SetTutorialPuzzle3Complete(bool set)
    {
        tutorialPuzzle3Complete = set;
    }

    public void SetTutorialComplete(bool set)
    {
        tutorialComplete = set;
    }

    private void SetPopUp(string text)
    {
        audioPlayer.PlayExoClip();
        popUp.SetActive(true);
        popUpText.text = text;
    }

    IEnumerator ChangeText(float delay, string text)
    {
        yield return new WaitForSeconds(delay);
        SetPopUp(text);
    }

    IEnumerator DisableWithTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        popUp.SetActive(false);
    }
}
