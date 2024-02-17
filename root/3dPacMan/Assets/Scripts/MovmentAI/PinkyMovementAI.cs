using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PinkyMovementAI : Ghost
{
    public override void Start()
    {
        //forces the model to continually update path
        continousUpdate = true;
    }

    public override void DetermineNewTarget()
    {
        //sets the new nav position to be always in front of the player
        //will attempt to navigate into walls but that should be fine?
        UpdateTargetPosition();
    }
    public override void UpdateTargetImmediately()
    {
        UpdateTargetPosition();
    }

    //set the position to always be in front of the players current position
    private void UpdateTargetPosition()
    {
        if (player!= null)
        {
            Vector3 targetPosition = player.transform.position + player.transform.forward * 4f;
            navMeshAgent.SetDestination(targetPosition);
        }
        else
        {
            Logger.LogError("PlayerTransform is not assigned. Please assign the player's transform in the Inspector.");
        }
    }
}
