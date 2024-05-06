using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    [SerializeField] Animator activationAnimator;
    [SerializeField] GameObject tiger;
    [SerializeField] Material tigerDeactivatedMaterial;
    [SerializeField] Material tigerActivationMaterial;
    [SerializeField] GameObject activatedLight;
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;
    [SerializeField] BoxCollider narrationTrigger;

    Story story;
    MainStory mainStory;
    AudioPlayer audioPlayer;

    private void Awake() 
    {
        story = FindObjectOfType<Story>();  
        mainStory = FindObjectOfType<MainStory>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

   
    void Start()
    {
        tiger.GetComponent<SkinnedMeshRenderer>().material = tigerDeactivatedMaterial;
        activatedLight.SetActive(false);
        activationAnimator.enabled = false;
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "DoorPowerSource")
        {
            tiger.GetComponent<SkinnedMeshRenderer>().material = tigerActivationMaterial;
            activatedLight.SetActive(true);
            activationAnimator.enabled = true;
            audioPlayer.PlayRoarClip();
            Destroy(other.gameObject);
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
            narrationTrigger.enabled = false;
            story.OnExitingPuzzle1();
            mainStory.startHintTimer = false;
        }
    }
}
