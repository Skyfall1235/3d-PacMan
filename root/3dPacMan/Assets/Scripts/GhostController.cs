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

public class GhostController : MonoBehaviour
{
    //initialized in inspector
    [SerializeField] private GameObject[] ghost;

    void Start()
    {
        StartCoroutine(ReleaseTimer());
    }

    private void ReleaseGhost(int i)
    {
        //enable the AI script to start working
        Ghost enemy = ghost[i].GetComponent<Ghost>();
        if (enemy != null)
        {
            enemy.enabled = true;
        }
    }
    //coroutine for the release timer for the ghosts
    IEnumerator ReleaseTimer()
    {
        for(int i = 0; i < ghost.Length; i++ )
        {
            //turn the AI script on
            ReleaseGhost(i);
            yield return new WaitForSeconds(10);
        }
    }
    
}
