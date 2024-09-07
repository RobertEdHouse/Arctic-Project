using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    IdleSki,
    Move,
    Ski,
    Crouch
    
}

public class Player : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private float runningSpeed = 15f;

    public float WalkingSpeed => walkingSpeed;
    public float RunningSpeed => runningSpeed;

    public Vector3 movementVector = Vector3.zero;
    public StateType StateType { get; private set; } = StateType.Idle;

    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movementVector.x = x;
        movementVector.y = y;
        if (x != 0 || y != 0)
        {
            if(StateType == StateType.Idle)
                StateType = StateType.Move;
            else if(StateType == StateType.IdleSki)
                StateType = StateType.Ski;
        }
        else if (x == 0 && y == 0)
        {
            if(StateType == StateType.Move)
                StateType = StateType.Idle;
            else if(StateType == StateType.Ski)
                StateType = StateType.IdleSki;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(StateType == StateType.Idle)
                StateType = StateType.IdleSki;
            else if(StateType == StateType.IdleSki)
                StateType = StateType.Idle;
        }
    }
}
