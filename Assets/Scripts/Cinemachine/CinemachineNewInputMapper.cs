using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineNewInputMapper : MonoBehaviour
{
    /// <summary>Sensitivity multiplier for x-axis</summary>
    [Tooltip("Sensitivity multiplier for x-axis")]
    public float TouchSensitivityX = 10f;

    /// <summary>Sensitivity multiplier for y-axis</summary>
    [Tooltip("Sensitivity multiplier for y-axis")]
    public float TouchSensitivityY = 10f;

    /// <summary>Input channel to spoof for X axis</summary>
    [Tooltip("Input channel to spoof for X axis")]
    public string TouchXInputMapTo = "Mouse X";

    /// <summary>Input channel to spoof for Y axis</summary>
    [Tooltip("Input channel to spoof for Y axis")]
    public string TouchYInputMapTo = "Mouse Y";

    public float touchSensitivityMobile = 3f;
    public float autoRotateSensitivity = 0.01f;

    // Reference to the input action for looking around
    public StarterAssetsInputHandler lookAction;

    private CinemachineFreeLook _cinemachineFreeLook;
    private void Awake()
    {
        lookAction = new();
    }
    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    private void Start()
    {
        _cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        // Read the look input action value
        Vector2 lookValue = lookAction.Player.Look.ReadValue<Vector2>();

        if (axisName == TouchXInputMapTo)
            return lookValue.x / TouchSensitivityX;
        if (axisName == TouchYInputMapTo)
            return lookValue.y / TouchSensitivityY;

        if (!Keyboard.current.anyKey.isPressed)
        {
            _cinemachineFreeLook.m_XAxis.Value += autoRotateSensitivity;
        }

        // Default return value for other axes (if needed)
        return 0f;
    }
}
