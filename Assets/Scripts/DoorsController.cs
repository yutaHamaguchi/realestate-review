using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorsController : MonoBehaviour
{
    [SerializeField]
    private bool isDoorOpen = false;
    [SerializeField]
    private float openAngle = -90f;
    [SerializeField]
    private float closeAngle = -180f;
    private Transform doorToOpen;
    private void Start()
    {
        InputHandler.Instance.OnActionPerformed += OnPressAction;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToOpen = transform;
            CanvasController.Instance.EnableDoorText(true);
            CheckText();
        }
    }

    public void CheckText()
    {
        if (isDoorOpen)
        {
            if (CanvasController.Instance.gameLocale == "en")
                CanvasController.Instance.SetDoorText("Press 'E' to Close The Door");
            else
                CanvasController.Instance.SetDoorText("「Eキーを押してドアを閉める」");
        }
        else
        {
            if (CanvasController.Instance.gameLocale == "en")
                CanvasController.Instance.SetDoorText("Press 'E' to Open The Door");
            else
                CanvasController.Instance.SetDoorText("「Eキーを押してドアを開ける」");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToOpen = null;
            CanvasController.Instance.EnableDoorText(false);
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
    private void OnDisable()
    {
        InputHandler.Instance.OnActionPerformed -= OnPressAction;
    }
}
