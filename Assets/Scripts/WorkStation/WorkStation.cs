using UnityEngine;

public class WorkStation : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider2D interactionArea;
    [SerializeField] private RepairTask repairTask;
    [SerializeField] private Transform robotPosition;

    private Robot currentRobot;

    public void Interact(Player player)
    {
        if (currentRobot != null)
        {
            Debug.Log("WorkStation is already occupied.");
            return;
        }

        Robot robot = player.TakeCarriedRobot();

        if (robot == null)
        {
            Debug.Log("Player is not carrying a robot.");
            return;
        }

        currentRobot = robot;

        robot.transform.SetParent(robotPosition, false);
        robot.transform.localPosition = Vector3.zero;

        Debug.Log("Robot delivered to the WorkStation.");

        repairTask.StartRepair(player);
    }
}