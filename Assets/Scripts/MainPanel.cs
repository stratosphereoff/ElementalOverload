using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;

    private void OnEnable() 
    {
        restartButton.SetActive(false);
    }

    private void OnDisable() 
    {
        restartButton.SetActive(true);
    }
}
