using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int componentCount;
    public int totalComponent;

    public int coinCount;
    public int totalCoin;

    public int zombieKilled = 0;

    public GameObject playerGun;

    public bool SpendComponent(int count)
    {
        if (componentCount < count)
            return false;
        else
        {
            componentCount -= count;
            return true;
        }
    }
    
}
