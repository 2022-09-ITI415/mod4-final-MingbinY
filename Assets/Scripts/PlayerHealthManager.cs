using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealthManager : BasicHealthManager
{
    public float regenInterval;
    public float regenTimer;
    public AudioClip[] hurtSFX;
    public AudioSource audioSource;

    [Tooltip("Per second")]
    public float regenRate;

    private void Awake()
    {
        if (!audioSource)
            audioSource = GetComponent<AudioSource>();
    }

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
        audioSource.PlayOneShot(hurtSFX[Random.Range(0, hurtSFX.Length)]);
    }

    public override void Death()
    {
        GetComponent<FirstPersonController>().enabled = false;
        FindObjectOfType<GameManager>().GameOver();
    }
}
