using UnityEngine;

public class DeliveryStation : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManager gameManager;

    public void Interact(Player player)
    {
        Robot robot = player.TakeCarriedRobot();

        if (robot == null)
        {
            Debug.Log("Player is not carrying a robot.");
            return;
        }

        if (robot.HasProblems())
        {
            Debug.Log("Robot still has unrepaired problems.");
            player.TakeRobot(robot);
            return;
        }

        gameManager.RobotCompleted();

        Destroy(robot.gameObject);
    }
}