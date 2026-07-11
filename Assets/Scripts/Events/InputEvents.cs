using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvents
{
    public event Action<InputAction.CallbackContext> Move;
    public void OnMove(InputAction.CallbackContext context)
    {
        Move?.Invoke(context);
    }
}
