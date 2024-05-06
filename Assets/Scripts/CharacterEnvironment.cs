using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnvironment : MonoBehaviour
{
    [SerializeField] GameObject rain;
    [SerializeField] bool isInside;
    
    void Start()
    {
        rain.SetActive(true);
        isInside = false;
    }

   
    void Update()
    {
        if (isInside)
        {
            rain.SetActive(false);
        }
        else if (!isInside)
        {
            rain.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "entrance")
        {
            isInside = true;
        }    

        if (other.tag == "entrance" && isInside == true)
        {
            isInside = false;
        }
    }
}
