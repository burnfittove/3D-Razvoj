using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rb;
    private Animator _animator;
    private PlayerStamina _playerStamina;
    private HealthComponent _playerHealth;
    public SkinnedMeshRenderer _playerRenderer;

    private Vector2 _movementDirection;
    public float movementSpeed;
    public float runningSpeed;
    private bool isRunning;
    private bool _isEnabled;
    private bool _isHidden;
    public bool isDead;
    
    // ##### DEBUG #####
    private Camera cam;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _playerStamina = GetComponent<PlayerStamina>();
        _playerHealth = GetComponent<HealthComponent>();
    }

    private void Start()
    {
        _isEnabled = true;

        if (!GameEventManager.instance)
        {
            Debug.LogError("No GameEventManager found in scene.");
            return;
        }
        
        GameEventManager.instance.inputEvents.Move += Move;
        GameEventManager.instance.inputEvents.Run += Run;
        GameEventManager.instance.miscellaneousEvents.SetPlayerCharacterActiveState += SetActiveState;
        GameEventManager.instance.sceneEvents.OnTransitionStarted += TransitionStarted;
        GameEventManager.instance.sceneEvents.OnTransitionCompleted += TransitionCompleted;
        SceneManager.sceneLoaded += UpdateCameraReference;
        
        cam = Camera.main;
    }

    private void SetActiveState(bool state)
    {
        _isHidden = !state; // When someone says 'set active state to inactive (false)' this says 'it's hidden (true)'
    }

    private void Update()
    {
        _playerRenderer.enabled = !_isHidden;    // Show or hide the player
        
        if (_isHidden) return;
        
        if (isDead)
        {
            if (_playerHealth.CurrentHealth <= 0) return;
            isDead = false;
        }
        
        if (!_isEnabled) return;
        
        // If running, consume stamina
        if (isRunning && _movementDirection != Vector2.zero) _playerStamina.ConsumeStamina();
        
        // If there is no more stamina, force walking
        if (_playerStamina.hasStamina) return;
        isRunning = false;
        _animator?.SetBool("isRunning", false);
    }

    private void FixedUpdate()
    {
        if (!_isEnabled || isDead || _isHidden) return;
        if (_isHidden) return;
        
        // Move
        UpdateMovement();
        
        if (_movementDirection == Vector2.zero) return;
        UpdateRotation();
    }

    private void Move(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();
        if (context.started) _animator?.SetBool("isMoving", true);
        if (context.canceled) _animator?.SetBool("isMoving", false);
    }

    private void UpdateRotation()
    {
        if (!cam) return;
        var movementRotation = Mathf.Atan2(_movementDirection.x, _movementDirection.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        // transform.rotation = Quaternion.Euler(Vector3.up * movementRotation);
        _rb.MoveRotation(Quaternion.Euler(Vector3.up * movementRotation));
    }

    private void UpdateMovement()
    {
        // Movement direction translated into 3 dimensions
        var translatedMovementDirection = Quaternion.AngleAxis(cam.transform.eulerAngles.y, Vector3.up) *   // Movement direction relative to the camera...
                                          new Vector3(_movementDirection.x, 0, _movementDirection.y) *              // then multiply with the given input...
                                          (isRunning ? runningSpeed : movementSpeed);                               // then decide which speed to use.
        _rb?.MovePosition(_rb.position + translatedMovementDirection * Time.deltaTime);
    }

    private void Run(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
        if (context.started) _animator?.SetBool("isRunning", true);
        if (context.canceled) _animator?.SetBool("isRunning", false);
    }

    private void UpdateCameraReference(Scene scene, LoadSceneMode mode) => cam = Camera.main;

    private void TransitionStarted()
    {
        _isEnabled = false;
        _animator.speed = 0;
    }

    private void TransitionCompleted()
    {
        _isEnabled = true;
        _animator.speed = 1;
    }
}
