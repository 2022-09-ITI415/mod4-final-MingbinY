using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealthManager : BasicHealthManager
{
    public float regenInterval;
    public float regenTimer;

    public int regenRate;

    private void FixedUpdate()
    {
        if (Time.time >= regenTimer && health < maxHealth)
        {
            health++;
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        regenTimer = Time.time + regenInterval;
    }

    public override void Death()
    {
        GetComponent<FirstPersonController>().enabled = false;
    }
}
