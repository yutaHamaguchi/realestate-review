using TMPro;
using UnityEngine;

public class CanvasController : SingletonMonobehaviour<CanvasController>
{
    [SerializeField]
    private TextMeshProUGUI doorText;

    public void EnableDoorText(bool check)
    {
        doorText.gameObject.SetActive(check);
    }
    public void SetDoorText(string text)
    {
        doorText.text = text;
    }
    public string GetDoorText()
    {
        return doorText.text;
    }
}
