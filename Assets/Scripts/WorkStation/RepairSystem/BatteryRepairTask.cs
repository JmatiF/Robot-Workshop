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

        Debug.Log("Battery repair started. Hold SPACE.");
    }

    private void Update()
    {
        if (!isRepairing)
            return;

        if (Keyboard.current.spaceKey.isPressed)
        {
            currentCharge += Time.deltaTime;

            float percentage = currentCharge / chargeTime * 100f;

            Debug.Log($"Battery charge: {percentage:F0}%");

            if (currentCharge >= chargeTime)
            {
                CompleteRepair();
            }
        }
        else if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            Debug.Log("Battery released too early. Charge reset.");
            currentCharge = 0f;
        }
    }

    private void CompleteRepair()
    {
        isRepairing = false;

        Debug.Log("BATTERY REPAIR COMPLETED!");

        repairProgress.StartProgress();
    }
}