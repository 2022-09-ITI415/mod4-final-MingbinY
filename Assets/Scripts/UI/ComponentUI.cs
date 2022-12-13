using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentUI : MonoBehaviour
{
    Text componentCount;
    Inventory inventory;

    private void Start()
    {
        componentCount = GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        componentCount.text = inventory.componentCount.ToString();
    }
}
