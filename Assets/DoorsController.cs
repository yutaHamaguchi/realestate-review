using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorsController : MonoBehaviour
{
    [SerializeField]
    private bool isDoorOpen = false;
    [SerializeField]
    StarterAssetsInputHandler starterAsstesInput;
    [SerializeField]
    private float openAngle = -90f;
    [SerializeField]
    private float closeAngle = -180f;
    private Transform doorToOpen;
    private void Awake()
    {
        starterAsstesInput = new();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToOpen = transform;
            CanvasController.instance.EnableDoorText(true);
            CheckText();
        }
    }

    public void CheckText()
    {
        if (isDoorOpen)
        {
            CanvasController.instance.SetDoorText("Press 'E' to Close The Door");
        }
        else
        {
            CanvasController.instance.SetDoorText("Press 'E' to Open The Door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToOpen = null;
            CanvasController.instance.EnableDoorText(false);
        }
    }
    private void OnPressAction(InputAction.CallbackContext context)
    {
        if (doorToOpen)
        {
            if (isDoorOpen)
            {
                doorToOpen.DOLocalRotate(new Vector3(0f, closeAngle, 0f), 1f).OnComplete(() =>
                {
                    isDoorOpen = false;
                    CheckText();
                });
            }
            else
            {
                doorToOpen.DOLocalRotate(new Vector3(0f, openAngle, 0f), 1f).OnComplete(() =>
                {
                    isDoorOpen = true;
                    CheckText();
                });
            }
        }
    }
}
