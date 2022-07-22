using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class InputParser : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlsActions;

    [Header("Scripts")] 
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private HealthData playerHealthData;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlsActions = _playerInput.actions;
    }

    private void FixedUpdate()
    {
        var moveInput = _playerControlsActions["Move"].ReadValue<Vector2>();
        playerMovement.Move(moveInput);
        
        _playerControlsActions["HealtTest"].started += (InputAction.CallbackContext context) => playerHealthData.TakeDamage(2);
    }
}
