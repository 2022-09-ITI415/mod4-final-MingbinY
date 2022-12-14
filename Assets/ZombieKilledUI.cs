using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieKilledUI : MonoBehaviour
{
    Inventory inventory;
    Text text;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = inventory.zombieKilled.ToString();
    }
}
