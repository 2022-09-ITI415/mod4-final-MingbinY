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
    public bool isAlive;
    public float health = 0;
    public int maxHealth = 100;
    public BodyType bodyType = BodyType.Flesh;

    public void Start()
    {   
        isAlive = true;
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        if (!isAlive)
            return;
        health -= damage;
        if (health < 0)
        {
            isAlive=false;
            Death();
        }
    }

    public virtual void Death()
    {

    }
}
