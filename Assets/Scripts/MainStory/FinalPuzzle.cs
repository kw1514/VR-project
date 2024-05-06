using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FinalPuzzle : MonoBehaviour
{
    [Header("Symbol Light Up Delay")]
    [SerializeField] float delay = 1;

    [Header("Big Symbols")]
    [SerializeField] GameObject leafSymbol;
    [SerializeField] GameObject sunSymbol;
    [SerializeField] GameObject crossSymbol;

    [Header("Mini Symbols")]
    [SerializeField] GameObject miniLeafSymbol;
    [SerializeField] GameObject miniSunSymbol;
    [SerializeField] GameObject miniCrossSymbol;

    [Header("Sword")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject rip;

    [Header("Material")]
    [SerializeField] Material deactiveMaterial;
    [SerializeField] Material activeMaterial;

    private bool leafSymbolActive = false;
    private bool sunSymbolActive = false;
    private bool crossSymbolActive = false;
    private bool puzzleComplete = false;
    private bool swordPickUp = false;

    Story story;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        story = FindObjectOfType<Story>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        DeactivateSymbol(leafSymbol);
        DeactivateSymbol(sunSymbol);
        DeactivateSymbol(crossSymbol);
        DeactivateSymbol(miniLeafSymbol);
        DeactivateSymbol(miniSunSymbol);
        DeactivateSymbol(miniCrossSymbol);

        sword.GetComponent<Rigidbody>().useGravity = false;
        rip.SetActive(false);
        sword.SetActive(false);
    }


    void Update()
    {
        // puzzle is finished
        if (leafSymbolActive && sunSymbolActive && crossSymbolActive)
        {
            leafSymbol.GetComponent<BoxCollider>().enabled = false;
            sunSymbol.GetComponent<BoxCollider>().enabled = false;
            crossSymbol.GetComponent<BoxCollider>().enabled = false;
            // puzzleComplete = true;

            sword.SetActive(true);
        }

        if (puzzleComplete)
        {
            story.OnSolvingFinalPuzzle();
            puzzleComplete = false;
        }

        if (swordPickUp)
        {
            sword.GetComponent<Rigidbody>().isKinematic = false;
            sword.GetComponent<Rigidbody>().useGravity = true;

            rip.SetActive(true);

            story.OnPickingSword();
            swordPickUp = false;
        }
    }

    public void ActivateLeaf()
    {
        // right order
        if (sunSymbolActive && !crossSymbolActive)
        {
            leafSymbolActive = true;
            ActivateSymbol(leafSymbol);
            ActivateSymbol(miniLeafSymbol);
        }
        // wrong order
        else
        {
            leafSymbolActive = false;
            sunSymbolActive = false;
            crossSymbolActive = false;

            StartCoroutine(WrongOrderActivate(leafSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(sunSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(crossSymbol, delay));

            // mini symbols
            StartCoroutine(WrongOrderActivate(miniLeafSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(miniSunSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(miniCrossSymbol, delay));

            story.OnFinalPuzzleWrongOrder();
        }
    }

    public void ActivateSun()
    {
        // right order
        if (!leafSymbolActive && !crossSymbolActive)
        {
            sunSymbolActive = true;
            ActivateSymbol(sunSymbol);
            ActivateSymbol(miniSunSymbol);
        }
        // wrong order
        else
        {
            sunSymbolActive = false;

            story.OnFinalPuzzleWrongOrder();
        }
    }

    public void ActivateCross()
    {
        // right order
        if (sunSymbolActive && leafSymbolActive)
        {
            crossSymbolActive = true;
            ActivateSymbol(crossSymbol);
            ActivateSymbol(miniCrossSymbol);
            puzzleComplete = true;
        }
        // wrong order
        else
        {
            crossSymbolActive = false;
            leafSymbolActive = false;
            sunSymbolActive = false;

            StartCoroutine(WrongOrderActivate(crossSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(leafSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(sunSymbol, delay));

            // mini symbols
            StartCoroutine(WrongOrderActivate(miniCrossSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(miniLeafSymbol, delay));
            StartCoroutine(WrongOrderDeactivate(miniSunSymbol, delay));
            story.OnFinalPuzzleWrongOrder();
        }
    }

    public void PickUpSword()
    {
        swordPickUp = true;
    }

    public void DropSword()
    {
        sword.GetComponent<Rigidbody>().isKinematic = false;
        sword.GetComponent<Rigidbody>().useGravity = true;
    }

    private void ActivateSymbol(GameObject symbol)
    {
        audioPlayer.PlayActivateClip();
        symbol.GetComponent<MeshRenderer>().material = activeMaterial;
    }

    private void DeactivateSymbol(GameObject symbol)
    {
        symbol.GetComponent<MeshRenderer>().material = deactiveMaterial;
    }

    IEnumerator WrongOrderActivate(GameObject symbol, float delay)
    {
        audioPlayer.PlayActivateClip();
        ActivateSymbol(symbol);
        yield return new WaitForSeconds(delay);
        DeactivateSymbol(symbol);
    }

    IEnumerator WrongOrderDeactivate(GameObject symbol, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioPlayer.PlayActivateClip();
        DeactivateSymbol(symbol);
    }
}
