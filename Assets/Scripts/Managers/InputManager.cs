using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void Move(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.OnMove(context);
    }
}
