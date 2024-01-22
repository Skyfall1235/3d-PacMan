////////////////////////////////////////////////
///Assignment/Lab/Project: PacMan
/////Name: Wyatt Murray
/////Section: SGD285.4147
/////Instructor: Aurore Locklear
/////Date: 1/21/24
////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkyMovementAI : Ghost
{

    //as much as id like to write the code for inky, his original programming would be too difficult, so im giving him blinkys AI
    public override void Start()
    {

    }

    public override void DetermineNewTarget()
    {
        SetTargetPosition(player.transform.position);
    }
}
