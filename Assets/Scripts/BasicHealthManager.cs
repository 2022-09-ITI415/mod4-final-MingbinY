using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    Flesh,
    other
}

public class BasicHealthManager : MonoBehaviour
{
    public int health = 0;
    public int maxHealth = 100;
    public BodyType bodyType = BodyType.Flesh;

    private void Start()
    {
        health = maxHealth;
    }
}
