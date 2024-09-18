using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls playerControls; //���� ������ �� ���������� � ���������� InputSystemAsset, ����� ��������� ������ ������ 

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerControls(); //����� ������� ���������
    }


    private void Start()
    {
        //������������� �� ���������� ��������� ������� ������� �����������
        playerControls.Player.Move.started += MoveHandler;
    }

    private void MoveHandler(InputAction.CallbackContext context) // ��� ���������� ������� InputSystem, ����� ������������ ��� �� �� �������������� Update
    {
        //�� �������� Callback �� ������� � ����� ��� ����������
        moveDirection = context.ReadValue<Vector2>(); //ReadValue ����� true ���� ������ ��� ��� ����� ������������ � � if 

        #region DebugLog

        if (moveDirection != Vector2.zero)
        {
            Debug.Log(moveDirection.ToString());
        }

        #endregion
    }

    private void Update() //��� ������ ��� ������������ InputSystem �������� � Update
    {
        // ����� �������� Vector2 ������� ������������ ����������� ��������
        var moveVectror = playerControls.Player.Move.ReadValue<Vector2>();

        #region DebugLog

        //if (moveVectror != Vector2.zero)
        //{
        //    Debug.Log(moveVectror.ToString());
        //}

        #endregion

    }


    private void OnEnable()
    {
        //���������� ����� ����������� ��������
        playerControls.Enable();
    }

    private void OnDisable()
    {
        //� ����� ��������� (��� ��������� ������ ������)
        playerControls.Disable();
        playerControls.Player.Move.started -= MoveHandler;
    }

}
