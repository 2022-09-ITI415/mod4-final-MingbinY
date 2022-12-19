using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoiceOverManager : MonoBehaviour
{
    public AudioClip[] voiceClips;
    AudioSource audioSource;
    int index;

    private void Awake()
    {
        index = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayClip();
    }

    public void PlayClip()
    {
        AudioClip clip = voiceClips[index];
        index++;
        audioSource.PlayOneShot(clip);
    }
}
