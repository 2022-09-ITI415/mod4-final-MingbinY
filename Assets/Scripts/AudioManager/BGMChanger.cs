using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    bool triggered = false;

    public AudioSource audioSource;
    public AudioClip bgmToChange;

    private void Start()
    {
        triggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            if (audioSource && bgmToChange)
            {
                audioSource.clip = bgmToChange;
                audioSource.Play();
                audioSource.loop = true;
            }
                
        }
    }
}
