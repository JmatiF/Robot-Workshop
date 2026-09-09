using UnityEngine;

public class RobotSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private GameObject robotPrefab;
    [SerializeField] private GameManager gameManager;

    private float timer;
    private Robot currentRobot;

    private void Update()
    {
        if (currentRobot != null)
            return;

        if (!gameManager.CanSpawnRobot())
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRobot();
        }
    }

    private void SpawnRobot()
    {
        GameObject robotObject = Instantiate(
            robotPrefab,
            transform.position,
            Quaternion.identity
        );

        currentRobot = robotObject.GetComponent<Robot>();

        gameManager.RobotSpawned();

        Debug.Log("Robot nuevo esperando reparación.");
    }

    public void Interact(Player player)
    {
        if (currentRobot == null)
            return;

        if (!player.TakeRobot(currentRobot))
            return;

        Debug.Log("Robot removed from Spawner.");

        currentRobot = null;
    }
}