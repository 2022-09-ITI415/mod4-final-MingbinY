using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool shipFixed = false;
    public GameObject[] UIs;

    private void Awake()
    {
        shipFixed = false;
    }
    public void OnInteraction()
    {
        if (!shipFixed)
            return;
        GetComponent<Interactable>().enabled = false;
        FindObjectOfType<GameManager>().StartGameEndTimeline();
    }

    public void TurnOffUI()
    {
        foreach (GameObject ui in UIs)
        {
            ui.SetActive(false);
        }
    }
}
