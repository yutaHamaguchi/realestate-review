using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; }
    [SerializeField]
    private TextMeshProUGUI doorText;
    public TextMeshProUGUI instructionsText;
    public MainPopup frontPanel;
    public InstructionPopup instructionPanel;
    public Player player;
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
    }
    private void Start()
    {
        InputHandler.Instance.OnSettingsPerformed += OnPressSettings;
    }
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

    public void EnableFreeView(bool check)
    {
        frontPanel.Hide();
        player.ActivatePlayer(check);

        if (check)
            ShowSettingsPanel();

        instructionPanel.ShowHide(check);
    }

    public void OnPressSettings(InputAction.CallbackContext context)
    {
        ShowSettingsPanel();
    }

    public void ShowSettingsPanel()
    {
        if (InputHandler.Instance.isPlayerActive)
        {
            if (!instructionPanel.isShown)
            {
                instructionPanel.Show();
            }
            else
            {
                instructionPanel.Hide();
            }
        }
    }
    private void OnDisable()
    {
        InputHandler.Instance.OnSettingsPerformed -= OnPressSettings;
    }
}
