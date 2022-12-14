using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ship : MonoBehaviour
{
    public bool shipFixed = false;

    private void Awake()
    {
        shipFixed = false;
    }
    public void OnInteraction()
    {
        if (!shipFixed)
            return;
        GetComponent<Interactable>().enabled = false;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<GameManager>().GameComplete();
    }
}
