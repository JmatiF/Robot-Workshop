using TMPro;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    public void ShowWin()
    {
        gameObject.SetActive(true);
        resultText.text = "YOU WIN!";
    }

    public void ShowLose()
    {
        gameObject.SetActive(true);
        resultText.text = "GAME OVER!";
    }
}