using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }
    private StarterAssetsInputHandler playerControls;

    public Vector2 LookInput { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsSprinting { get; private set; }
    public bool IsPerformingAction { get; private set; }
    public bool IsTeleporting { get; private set; }
    public bool Settings { get; private set; }

    public Player player;

    public bool isPlayerActive;

    // These events allow for custom actions to be added externally
    public event Action<InputAction.CallbackContext> OnActionPerformed;
    public event Action<InputAction.CallbackContext> OnActionCanceled;
    public event Action<InputAction.CallbackContext> OnSettingsPerformed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerControls = new StarterAssetsInputHandler();

        // Assign input actions to variables or events
        playerControls.Player.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Jump.performed += ctx => IsJumping = ctx.ReadValueAsButton();
        playerControls.Player.Jump.canceled += ctx => IsJumping = false;

        playerControls.Player.Sprint.performed += ctx => IsSprinting = ctx.ReadValueAsButton();
        playerControls.Player.Sprint.canceled += ctx => IsSprinting = false;

        playerControls.Player.Action.performed += ctx =>
        {
            IsPerformingAction = true;
            OnActionPerformed?.Invoke(ctx); // Trigger the external event
        };
        playerControls.Player.Action.canceled += ctx =>
        {
            IsPerformingAction = false;
            OnActionCanceled?.Invoke(ctx); // Trigger the external event
        };
        playerControls.Player.Settings.performed += ctx =>
        {
            Settings = false;
            OnSettingsPerformed?.Invoke(ctx); // Trigger the external event
        };
        playerControls.Player.TP.performed += ctx => IsTeleporting = ctx.ReadValueAsButton();
        playerControls.Player.TP.canceled += ctx => IsTeleporting = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        playerControls.Player.Look.performed -= ctx => LookInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.performed -= ctx => MoveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Jump.performed -= ctx => IsJumping = ctx.ReadValueAsButton();
        playerControls.Player.Jump.canceled -= ctx => IsJumping = false;

        playerControls.Player.Sprint.performed -= ctx => IsSprinting = ctx.ReadValueAsButton();
        playerControls.Player.Sprint.canceled -= ctx => IsSprinting = false;

        playerControls.Player.Action.performed -= ctx =>
        {
            IsPerformingAction = true;
            OnActionPerformed?.Invoke(ctx);
        };
        playerControls.Player.Action.canceled -= ctx =>
        {
            IsPerformingAction = false;
            OnActionCanceled?.Invoke(ctx);
        };
        playerControls.Player.Settings.performed -= ctx =>
        {
            Settings = false;
            OnSettingsPerformed?.Invoke(ctx); // Trigger the external event
        };

        playerControls.Player.TP.performed -= ctx => IsTeleporting = ctx.ReadValueAsButton();
        playerControls.Player.TP.canceled -= ctx => IsTeleporting = false;

        playerControls.Disable();
    }
}
