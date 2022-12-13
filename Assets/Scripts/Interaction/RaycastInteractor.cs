using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastInteractor : MonoBehaviour
{
    //This script is to be used with Interactable.cs
    Ray ray;
    RaycastHit hitInfo;

    [SerializeField]UnityEvent currentEvent;
    UnityEvent nullEvent;
    Camera mainCam;
    Transform raycastOrigin;
    Interactable interactable;

    public LayerMask raycastLayer;
    public float raycastDistance = 1f;
    public GameObject interactionHint;

    private void Awake()
    {
        mainCam = Camera.main;
        raycastOrigin = mainCam.transform;
    }

    private void Update()
    {
        CastRay();
        if (currentEvent != null)
        {
            //Show Interaction UI

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentEvent.Invoke();
                currentEvent = nullEvent;
            }
        }
        else
        {
            //Hide Interaction UI
        }
    }

    private void CastRay()
    {
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, raycastDistance, raycastLayer))
        {
            interactable = hitInfo.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentEvent = interactable.raycastEvent;
                interactionHint.SetActive(true);
            }
        }
        else
        {
            interactable = null;
            currentEvent = nullEvent;
            interactionHint.SetActive(false);
        }
    }
}
