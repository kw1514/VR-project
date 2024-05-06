using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Click")]
    [SerializeField] AudioClip clickClip;
    [SerializeField] [Range(0f, 1f)] float clickVolume = 1f;

    [Header("Roar")]
    [SerializeField] AudioClip roarClip;
    [SerializeField] [Range(0f, 1f)] float roarVolume = 1f;

    [Header("Exo")]
    [SerializeField] AudioClip exoClip;
    [SerializeField] [Range(0f, 1f)] float exoVolume = 1f;

    [Header("Activate")]
    [SerializeField] AudioClip activateClip;
    [SerializeField] [Range(0f, 1f)] float activateVolume = 1f;

    [Header("Pick Up")]
    [SerializeField] AudioClip pickUpClip;
    [SerializeField] [Range(0f, 1f)] float pickUpVolume = 1f;

    [Header("Drop")]
    [SerializeField] AudioClip dropClip;
    [SerializeField] [Range(0f, 1f)] float dropVolume = 1f;


    static AudioPlayer instance;

    void Awake() 
    {
        ManageSingleton();
    }

    void ManageSingleton() // makes sure that the audio plays throughout the scenes
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayClickClip()
    {
        PlayClip(clickClip, clickVolume);
    }

    public void PlayRoarClip()
    {
        PlayClip(roarClip, roarVolume);
    }

    public void PlayExoClip()
    {
        PlayClip(exoClip, exoVolume);
    }

    public void PlayActivateClip()
    {
        PlayClip(activateClip, activateVolume);
    }

    public void PlayPickUpClip()
    {
        PlayClip(pickUpClip, pickUpVolume);
    }

    public void PlaydropClip()
    {
        PlayClip(dropClip, dropVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
