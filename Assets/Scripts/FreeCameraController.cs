using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraController : MonoBehaviour
{
    private float _yaw;
    private float _pitch;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degrees to override the camera. Useful for fine-tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    [Tooltip("For locking the camera position on all axes")]
    public bool LockCameraPosition = false;

    [SerializeField]
    private float sensitivity = 30;

    [Tooltip("Minimum amount of drag input before camera moves")]
    [SerializeField]
    private float dragThreshold = 0.1f;

    private bool _isDragging;

    private void Update()
    {
        // Check if the left mouse button is held down (or touch is active)
        if (Mouse.current.leftButton.isPressed || Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            _isDragging = true;
        }
        else
        {
            _isDragging = false;
        }

        if (!LockCameraPosition && _isDragging)
        {
            Vector2 inputDelta = InputHandler.Instance.LookInput;

            // Only move the camera if the drag delta exceeds the threshold
            if (inputDelta.magnitude > dragThreshold)
            {
                _yaw += inputDelta.x * sensitivity * Time.deltaTime;
                _pitch += inputDelta.y * sensitivity * Time.deltaTime;

                _yaw = ClampAngle(_yaw, float.MinValue, float.MaxValue);
                _pitch = ClampAngle(_pitch, BottomClamp, TopClamp);

                transform.rotation = Quaternion.Euler(_pitch + CameraAngleOverride, _yaw, 0.0f);
            }
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
