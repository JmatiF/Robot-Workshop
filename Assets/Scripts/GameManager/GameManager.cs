using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int robotsToComplete = 5;
    [SerializeField] private float gameTime = 180f;

    private int completedRobots;
    private int spawnedRobots;
    private float timer;
    private bool gameFinished;

    private void Start()
    {
        timer = gameTime;
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

        Debug.Log($"Robots completed: {completedRobots}/{robotsToComplete}");

        if (completedRobots >= robotsToComplete)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameFinished = true;

        Debug.Log("YOU WIN!");
    }

    private void LoseGame()
    {
        gameFinished = true;

        Debug.Log("GAME OVER!");
    }
}