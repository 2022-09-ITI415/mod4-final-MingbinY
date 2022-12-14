using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageTerminal : MonoBehaviour
{
    //For some reason this is to be placed on the Table game object
    public AutomaticDoors doorController;
    public GameObject gunToShow;
    Inventory inventory;

    public GameObject textsToHide;
    public GameObject textsToShow;
    public GameObject zombieSpawners;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public void OnInteraction()
    {
        if (inventory != null)
        {
           if (inventory.SpendComponent(3))
            {
                gunToShow.SetActive(true);
                doorController.Unlock();
                textsToHide.SetActive(false);
                textsToShow.SetActive(true);
                zombieSpawners.SetActive(true);
                FindObjectOfType<TaskManager>().NextTask();
                GetComponent<Interactable>().enabled = false;
            }
            else
            {
                return;
            }
        }
    }

}
