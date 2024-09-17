using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls playerControls;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }


    private void Start()
    {
        playerControls.Player.Move.started += MoveHandler;
    }

    private void MoveHandler(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        var move = playerControls.Player.Move.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            Debug.Log(move.ToString());
        }
    }


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.Move.started -= Move;
    }

}
