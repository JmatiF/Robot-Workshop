using UnityEngine;
using UnityEngine.InputSystem;

public class BatteryRepairTask : RepairTask
{
    [SerializeField] private float chargeTime = 3f;

    private float currentCharge;
    private bool isRepairing;

    public override void StartRepair(Player player)
    {
        if (isRepairing)
            return;

        isRepairing = true;
        currentCharge = 0f;

        repairUI.ShowText("HOLD SPACE");
    }

    private void Update()
    {
        if (!isRepairing)
            return;

        if (Keyboard.current.spaceKey.isPressed)
        {
            currentCharge += Time.deltaTime;

            if (currentCharge >= chargeTime)
            {
                CompleteRepair();
            }
        }
        else if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            currentCharge = 0f;
        }
    }

    private void CompleteRepair()
    {
        isRepairing = false;

        repairUI.Hide();
        repairProgress.StartProgress();
    }
}