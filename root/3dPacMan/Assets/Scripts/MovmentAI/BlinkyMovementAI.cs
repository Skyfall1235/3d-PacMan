using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyMovementAI : Ghost
{
    public override void DetermineNewTarget()
    {
        SetTargetPosition(player.transform.position);
    }
}
