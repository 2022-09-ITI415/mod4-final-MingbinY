using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            FindObjectOfType<PlayerVoiceOverManager>().PlayClip();
        }
    }
}
