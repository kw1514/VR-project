using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    [SerializeField] GameObject lightOrb;
    [SerializeField] GameObject placedLightOrb;
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;

    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        lightOrb.SetActive(true);
        placedLightOrb.SetActive(false);
        openDoor.SetActive(false);
        closedDoor.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DoorPowerSource3")
        {
            Destroy(lightOrb);
            audioPlayer.PlayClickClip();
            placedLightOrb.SetActive(true);
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
        }
    }
}
