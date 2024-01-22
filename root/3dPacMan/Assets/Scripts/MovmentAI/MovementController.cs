using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

[RequireComponent(typeof(CharacterController))]

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 1f;
    
    public Direction currentDirection;
    //for before and end game states
    public bool canMove = false;

    public GameObject resetPos;

    //required component
    public CharacterController charController
    { 
        get { return GetComponent<CharacterController>(); } 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = Direction.none;
    }

    // Update is called once per frame
    void Update()
    {
        //takeinput handles directional calls
        Direction chosenDir = TakeInput();
        //movement is applied if direction isnot empty
        MovePlayer(chosenDir);


    }

    private void MovePlayer(Direction chosenDir)
    {
        if(chosenDir == Direction.none) { /*Logger.LogWarning($"Direction is {chosenDir}");*/ return; }
        //convert direction
        Vector3 localDirection = ConvertDirectionToVector3(chosenDir);

        charController.Move(localDirection * moveSpeed * Time.deltaTime);
    }

    public void SetPlayerPosition()
    {
        gameObject.transform.position = resetPos.transform.position;
    }

    private Direction TakeInput()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                currentDirection = Direction.left;
                return Direction.left; 
            }
            else if (Input.GetKey(KeyCode.RightArrow)) 
            {
                currentDirection = Direction.right;
                return Direction.right; 
            }
            else if (Input.GetKey(KeyCode.UpArrow)) 
            {
                currentDirection = Direction.up;
                return Direction.up; 
            }
            else if (Input.GetKey(KeyCode.DownArrow)) 
            {
                currentDirection = Direction.down;
                return Direction.down; 
            }
            //if no change to the direct, stay same course
            else return currentDirection;
        }
        else
        {
#if UNITY_EDITOR
            Logger.LogWarning("Unable to move");
#endif
            return Direction.none;
        }
    }
    private Vector3 ConvertDirectionToVector3(Direction dir)
    {
        //its gotta be somewhere, and it was this or a dictionary and a total remap of the directions which im not gonna do
        if (dir == Direction.left) { return Vector3.left; }
        else if (dir == Direction.right) { return Vector3.right; }
        else if (dir == Direction.up) { return Vector3.forward; }
        else if (dir == Direction.down) { return Vector3.back; }
        return Vector3.zero;
    }

    public void StopPlayer()
    {
#if UNITY_EDITOR
        Logger.LogWarning("Stopped Player");
#endif
        currentDirection = Direction.none;
    }

    public virtual void CustomAction()
    {
        //empty
    }
    private void OnCollisionEnter(Collision collision)
    {
        CustomAction();
    }

    public enum Direction { left, right, up, down, none }
}
