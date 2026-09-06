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

    public void ShowSequence(Key[] sequence)
    {
        repairText.gameObject.SetActive(true);

        string text = "";

        foreach (Key key in sequence)
        {
            text += key + " ";
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