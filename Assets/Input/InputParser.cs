using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputParser : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlsActions;
    
    [Header("Scripts")] 
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlsActions = _playerInput.actions;
    }

    private void FixedUpdate()
    {
        var moveInput = _playerControlsActions["Move"].ReadValue<Vector2>();
        playerMovement.Move(moveInput);
    }
}
