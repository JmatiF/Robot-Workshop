using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int robotsToComplete = 5;
    [SerializeField] private float gameTime = 180f;
    [SerializeField] private TMP_Text robotsText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameEndUI gameEndUI;

    private int completedRobots;
    private int spawnedRobots;
    private float timer;
    private bool gameFinished;

    private void Start()
    {
        timer = gameTime;
        UpdateRobotsText();
        UpdateTimerText();
    }

    private void Update()
    {
        if (gameFinished)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 0f;
            LoseGame();
        }

        UpdateTimerText();
    }

    public bool CanSpawnRobot()
    {
        return spawnedRobots < robotsToComplete;
    }

    public void RobotSpawned()
    {
        spawnedRobots++;
    }

    public void RobotCompleted()
    {
        completedRobots++;

        UpdateRobotsText();

        if (completedRobots >= robotsToComplete)
        {
            WinGame();
        }
    }

    private void UpdateRobotsText()
    {
        robotsText.text = $"ROBOTS: {completedRobots} / {robotsToComplete}";
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = $"TIME: {minutes:00}:{seconds:00}";
    }

    private void WinGame()
    {
        gameFinished = true;
        gameEndUI.ShowWin();
    }

    private void LoseGame()
    {
        gameFinished = true;
        gameEndUI.ShowLose();
    }
}