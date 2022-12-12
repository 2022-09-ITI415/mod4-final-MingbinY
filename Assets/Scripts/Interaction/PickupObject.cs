using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public void PickupComponent()
    {
        Inventory inventory = FindObjectOfType<Inventory>();

        if (inventory != null)
        {
            inventory.componentCount++;
            Destroy(gameObject);
        }
    }
}
