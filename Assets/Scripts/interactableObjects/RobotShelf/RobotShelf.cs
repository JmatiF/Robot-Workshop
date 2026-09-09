using UnityEngine;

public class RobotShelf : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform robotPosition;

    private Robot storedRobot;

    public void Interact(Player player)
    {
        if (storedRobot == null)
        {
            StoreRobot(player);
        }
        else
        {
            TakeRobot(player);
        }
    }

    private void StoreRobot(Player player)
    {
        Robot robot = player.TakeCarriedRobot();

        if (robot == null)
        {
            Debug.Log("Player is not carrying a robot.");
            return;
        }

        storedRobot = robot;

        robot.transform.SetParent(robotPosition, false);
        robot.transform.localPosition = Vector3.zero;

        Debug.Log("Robot stored on shelf.");
    }

    private void TakeRobot(Player player)
    {
        if (!player.TakeRobot(storedRobot))
        {
            Debug.Log("Player is already carrying a robot.");
            return;
        }

        Robot robot = storedRobot;
        storedRobot = null;

        robot.transform.SetParent(player.transform);
        robot.transform.localPosition = new Vector3(0f, 1f, 0f);

        Debug.Log("Robot taken from shelf.");
    }
}