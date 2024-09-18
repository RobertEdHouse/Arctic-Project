using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls playerControls; //Этот клласс мы генерируем в инспекторе InputSystemAsset, после настройки самого ассета 

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        playerControls = new PlayerControls(); //Нужно создать экземпляр
    }


    private void Start()
    {
        //Подписываемся на обновления состояния нажатия клавиши направления
        playerControls.Player.Move.started += MoveHandler;
    }

    private void MoveHandler(InputAction.CallbackContext context) // Это обработчик события InputSystem, можем использовать что бы не злоупотреблять Update
    {
        //Мы получаем Callback от события и можем его обработать
        moveDirection = context.ReadValue<Vector2>(); //ReadValue будет true если нажато так что можно использовать и в if 

        #region DebugLog

        if (moveDirection != Vector2.zero)
        {
            Debug.Log(moveDirection.ToString());
        }

        #endregion
    }

    private void Update() //Это пример как использовать InputSystem напрямую в Update
    {
        // Здесь получаем Vector2 который представляет направление движения
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
        //Управление нужно обязательно включить
        playerControls.Enable();
    }

    private void OnDisable()
    {
        //А потом выключить (для избежания утечки памяти)
        playerControls.Disable();
        playerControls.Player.Move.started -= MoveHandler;
    }

}
