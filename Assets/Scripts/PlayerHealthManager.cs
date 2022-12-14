using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealthManager : BasicHealthManager
{
    public float regenInterval;
    public float regenTimer;

    [Tooltip("Per second")]
    public float regenRate;

    private void FixedUpdate()
    {
        if (Time.time >= regenTimer && health < maxHealth)
        {
            health += (regenRate/60);
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
        FindObjectOfType<GameManager>().GameOver();
    }
}
