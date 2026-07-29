using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void Move(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.OnMove(context);
    }

    public void Run(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.OnRun(context);
    }
}
