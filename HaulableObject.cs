using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaulableObject : MonoBehaviour, IInteractable
{
    // amount of objects in the pile
    private int amountOf = 5;
    private bool isAlreadyHolding = false;

    // a cube that's always on the player, gets set active when player is holding a haulable object and set inactive when player is not
    public GameObject playerHoldingCube;

    public void Interact()
    {
        // player can pick up an object if they are not already holding one currently
        if (!isAlreadyHolding)
        {
            // if there's more than one in the pile, player just picks up an object and reduces the amount of objects in the pile
            if (amountOf > 1)
            {
                isAlreadyHolding = true;
                amountOf--;
            }
            // if player picks up the last object in the pile, the pile is set inactive so it disappears
            else
            {
                isAlreadyHolding = true;
                amountOf--;
                gameObject.SetActive(false);
            }

            // shows a cube on the player's body
            playerHoldingCube.SetActive(true);
        }

        // if player is already holding an object, they can drop the object into the pile
        else
        {
            // if there are already other objects in the pile, the player just adds the object there
            if (amountOf > 0)
            {
                isAlreadyHolding = false;
                amountOf++;
            }
            // if there's no other objects in the pile, the object pile shows up as player sets the object onto it
            else
            {
                isAlreadyHolding = false;
                amountOf++;
                gameObject.SetActive(true);
            }

            // hides the cube on the player's body
            playerHoldingCube.SetActive(false);
        }
    }
}
