using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputParser : MonoBehaviour
{
    private void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;
    }
}
