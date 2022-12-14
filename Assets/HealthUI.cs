using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    PlayerHealthManager healthManager;
    public Text healthText;

    private void Start()
    {
        healthManager = FindObjectOfType<PlayerHealthManager>();
    }
    private void Update()
    {
        int health = (int)healthManager.health;
        healthText.text = health.ToString();
    }
}
