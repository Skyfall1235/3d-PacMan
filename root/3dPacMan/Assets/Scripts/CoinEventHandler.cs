////////////////////////////////////////////////
///Assignment/Lab/Project: PacMan
/////Name: Wyatt Murray
/////Section: SGD285.4147
/////Instructor: Aurore Locklear
/////Date: 1/21/24
////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

public class CoinEventHandler : MonoBehaviour
{

    public UnityEvent onPlayerCollision = new();
    private void OnTriggerEnter(Collider other)
    {
        //if the coin collides with a player, call its unity event and set it to inactive
        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerCollision.Invoke();
            gameObject.SetActive(false);
        }
        
    }
}
