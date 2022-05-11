using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithObject : MonoBehaviour
{
    private GameObject raycastedObj;

    [SerializeField] private int rayLength = 5;
    [SerializeField] private Image crosshair;

    // references to objects' own scripts here

    private void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, rayLength))
        {
            if (hit.collider.tag == "InteractableObj")
            {
                CrosshairActive();

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    var _interactableObject = hit.collider.gameObject.GetComponent<IInteractable>();

                    if (_interactableObject != null)
                        _interactableObject.Interact();

                    Debug.Log("BUTTON HAS BEEN PRESSED!!!!!!");
                }
            }
        }
        else
        {
            CrosshairNormal();
        }
    }

    void CrosshairActive()
    {
        crosshair.color = Color.red;
    }

    void CrosshairNormal()
    {
        crosshair.color = Color.black;
    }
}
