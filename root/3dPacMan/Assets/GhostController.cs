using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //initialized in inspector
    [SerializeField] private GameObject[] ghost;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReleaseTimer());
    }
    //coroutine for the release timer for the
    //
    IEnumerator ReleaseTimer()
    {
        for(int i = 0; i < ghost.Length; i++ )
        {
            //turn the AI script on
            ReleaseGhost(i);
            yield return new WaitForSeconds(10);
        }
    }
    private void ReleaseGhost(int i)
    {
        Ghost enemy = ghost[i].GetComponent<Ghost>();
        if (enemy != null)
        {
            enemy.enabled = true;
        }
    }
}
