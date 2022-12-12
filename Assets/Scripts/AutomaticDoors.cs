using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorStatus
{
    Locked,
    Unlocked
}
public class AutomaticDoors : MonoBehaviour
{
    Animator animator;
    public DoorStatus status = DoorStatus.Unlocked;

    public GameObject lockedLights;
    public GameObject unlockedLights;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (status == DoorStatus.Locked)
        {
            unlockedLights.SetActive(false);
            lockedLights.SetActive(true);
        }
        else
        {
            lockedLights.SetActive(false);
            unlockedLights.SetActive(true);
        }
    }

    private void Update()
    {
        if (status == DoorStatus.Locked)
        {
            unlockedLights.SetActive(false);
            lockedLights.SetActive(true);
        }
        else
        {
            lockedLights.SetActive(false);
            unlockedLights.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (status == DoorStatus.Locked)
            return;

        if (other.tag == "Player")
        {
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", false);
        }
    }

    public void Unlock()
    {
        status = DoorStatus.Unlocked;
    }
}
