////////////////////////////////////////////////
///Assignment/Lab/Project: PacMan
/////Name: Wyatt Murray
/////Section: SGD285.4147
/////Instructor: Aurore Locklear
/////Date: 1/21/24
////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Ghost : MonoBehaviour
{
    [SerializeField] internal GameObject player;
    public UnityEvent CollideWithPlayer = new UnityEvent();
    internal bool continousUpdate = false;
    internal NavMeshAgent navMeshAgent;

    [SerializeField] internal float ghostSpeed = 1.0f;

    public virtual void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        DetermineNewTarget();
    }

    private void Update()
    {
        if(continousUpdate)
        {
            UpdateTargetImmediately();
            return;
        }
        // Check if the ghost has reached the target position
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 1f)
        {
            Logger.LogMessage($"ghost {gameObject.name} has reached its position");

            DetermineNewTarget();
        }

    }

    #region Overridable Methods
    public virtual void DetermineNewTarget()
    {
        //called when the target needs to be updated
    }
    public virtual void UpdateTargetImmediately()
    {
        //called if the continues update is true
    }

    public virtual void SetTargetPosition(Vector3 targetPosition)
    {
        // Set the destination to the target position
        navMeshAgent.SetDestination(targetPosition);
    }

    public virtual void SetRandomTargetPosition()
    {
        //gives a random location within the 
        Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        while(IsInsideWall(randomPosition))
        {
            //should regenerate until the path location is outside of a wall
            randomPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        }
        SetTargetPosition(randomPosition);
    }
    #endregion

    #region Internal methods
    internal Vector3 PickRandomLocationInSquare(float squareSize)
    {
        float halfSize = squareSize / 2f;

        Vector3 randomPosition = new Vector3(
            Random.Range(-halfSize, halfSize),
            0f,
            Random.Range(-halfSize, halfSize)
        );

        // Check if the random position is inside a GameObject with the tag "wall"
        while (IsInsideWall(randomPosition))
        {
            randomPosition = new Vector3(
                Random.Range(-halfSize, halfSize),
                0f,
                Random.Range(-halfSize, halfSize)
            );
        }

        return randomPosition;
    }
    internal bool IsInsideWall(Vector3 position)
    {
        // Raycast to check if there's a collider with the tag "wall" at the given position
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * 10f, Vector3.down, out hit, 20f))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    internal void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CollideWithPlayer.Invoke();
        }
    }
}
