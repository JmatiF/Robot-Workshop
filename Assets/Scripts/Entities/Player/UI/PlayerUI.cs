using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text robotInfoText;

    private void Awake()
    {
        robotInfoText.gameObject.SetActive(false);
    }

    public void ShowRobotInfo(Robot robot)
    {
        robotInfoText.gameObject.SetActive(true);

        string info = "ROBOT\nProblems:\n";

        foreach (Robot.Problem problem in robot.GetProblems())
        {
            info += problem + "\n";
        }

        robotInfoText.text = info;
    }

    public void HideRobotInfo()
    {
        robotInfoText.gameObject.SetActive(false);
    }
}