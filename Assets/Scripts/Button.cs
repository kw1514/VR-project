using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Material deactive;
    [SerializeField] Material active;
    
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = deactive; 
    }

    public void OnHover()
    {
        this.GetComponent<MeshRenderer>().material = active;
    }

    public void ExitHover()
    {
        this.GetComponent<MeshRenderer>().material = deactive; 
    }
}
