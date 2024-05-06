using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCubePuzzle : MonoBehaviour
{
    [SerializeField] Material activeMaterial;
    Story story;

    private void Start() 
    {
        story = FindObjectOfType<Story>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "DoorPowerSource")
        {
            Destroy(other.gameObject);
            this.GetComponent<MeshRenderer>().material = activeMaterial;
            story.SetTutorialPuzzle1Complete(true);
        }    
    }
}
