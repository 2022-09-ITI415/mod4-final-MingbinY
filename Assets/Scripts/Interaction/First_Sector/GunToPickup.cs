using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToPickup : MonoBehaviour
{
    public GameObject gunToShow;
    Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        gunToShow = inventory.playerGun;
    }

    public void OnInteraction()
    {
        gunToShow.SetActive(true);
        Destroy(gameObject);
    }
}
