using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSymbol : MonoBehaviour
{
    [SerializeField] Material activeMaterial;

    Story story;
    AudioPlayer audioPlayer;

    private void Start() 
    {
        story = FindObjectOfType<Story>();    
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void OnSelect()
    {
        audioPlayer.PlayActivateClip();
        this.GetComponent<MeshRenderer>().material = activeMaterial;
        story.SetTutorialPuzzle3Complete(true);
    }
}
