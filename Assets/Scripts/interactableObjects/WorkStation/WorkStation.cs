using UnityEngine;

public class WorkStation : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider2D interactionArea;
    [SerializeField] private RepairTask repairTask;
    [SerializeField] private Transform robotPosition;
    [SerializeField] private Robot.Problem requiredProblem;

    private Robot currentRobot;
    private bool repairCompleted;

    public void Interact(Player player)
    {
        // No robot in station: try to deliver one
        if (currentRobot == null)
        {
            StartRepair(player);
            return;
        }

        // Robot is still being repaired
        if (!repairCompleted)
        {
            Debug.Log("Robot is still being repaired.");
            return;
        }

        // Robot is repaired: take it
        TakeRobot(player);
    }

    private void StartRepair(Player player)
    {
        Robot robot = player.TakeCarriedRobot();

        if (robot == null)
        {
            Debug.Log("Player is not carrying a robot.");
            return;
        }

        if (!robot.HasProblem(requiredProblem))
        {
            Debug.Log($"This WorkStation requires: {requiredProblem}");
            player.TakeRobot(robot);
            return;
        }

        currentRobot = robot;
        repairCompleted = false;

        robot.transform.SetParent(robotPosition, false);
        robot.transform.localPosition = Vector3.zero;

        Debug.Log($"Robot delivered to WorkStation. Problem: {requiredProblem}");

        repairTask.StartRepair(player);
    }

    public void CompleteRepair()
    {
        if (currentRobot == null)
            return;

        currentRobot.RepairProblem(requiredProblem);

        repairCompleted = true;

        Debug.Log($"Robot repair completed: {requiredProblem}");
        Debug.Log("Robot is ready for pickup.");
    }

    private void TakeRobot(Player player)
    {
        Robot robot = currentRobot;

        currentRobot = null;
        repairCompleted = false;

        robot.transform.SetParent(null);
        player.TakeRobot(robot);

        Debug.Log("Repaired robot picked up.");
    }
}