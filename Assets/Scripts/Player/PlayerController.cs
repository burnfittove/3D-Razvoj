using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private CharacterController _characterController;

    private Vector2 _movementDirection;
    public int movementSpeed;

    private void Awake()
    {
        TryGetComponent(out _characterController);
    }

    private void Start()
    {
        GameEventManager.instance.inputEvents.Move += MovePlayer;
    }

    private void Update()
    {
        var translatedMovementDirection = new Vector3(_movementDirection.x, 0, _movementDirection.y) * movementSpeed;
        _characterController.Move(translatedMovementDirection * Time.deltaTime);
        if (_movementDirection == Vector2.zero) return;
        transform.rotation = Quaternion.LookRotation(translatedMovementDirection);
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        // Movement direction translated into 3 dimensions
        _movementDirection = context.ReadValue<Vector2>();
    }
}
