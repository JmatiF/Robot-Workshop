using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RepairUI : MonoBehaviour
{
    [SerializeField] private TMP_Text repairText;

    private void Awake()
    {
        repairText.gameObject.SetActive(false);
    }

    public void ShowSequence(Key[] sequence, int currentInput = 0)
    {
        repairText.gameObject.SetActive(true);

        string text = "";

        for (int i = 0; i < sequence.Length; i++)
        {
            if (i == currentInput)
                text += $"<color=yellow>{sequence[i]}</color> ";
            else
                text += $"{sequence[i]} ";
        }

        repairText.text = text;
    }

    public void ShowText(string text)
    {
        repairText.gameObject.SetActive(true);
        repairText.text = text;
    }

    public void Hide()
    {
        repairText.gameObject.SetActive(false);
    }
}