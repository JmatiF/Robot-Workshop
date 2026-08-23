using UnityEngine;

public class DeliveryStation : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        Robot robot = player.TakeCarriedRobot();

        if (robot == null)
        {
            Debug.Log("Player is not carrying a robot.");
            return;
        }

        Debug.Log("Robot delivered successfully!");

        Destroy(robot.gameObject);
    }
}
