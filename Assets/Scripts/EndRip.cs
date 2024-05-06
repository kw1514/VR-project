using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRip : MonoBehaviour
{
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        levelManager.LoadMainMenu();
    }
}
