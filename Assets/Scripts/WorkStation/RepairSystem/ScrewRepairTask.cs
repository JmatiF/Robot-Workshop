using UnityEngine;
using UnityEngine.InputSystem;

public class ScrewRepairTask : RepairTask
{
    private readonly Key[] clockwise =
    {
        Key.W,
        Key.D,
        Key.S,
        Key.A
    };

    private readonly Key[] counterClockwise =
    {
        Key.W,
        Key.A,
        Key.S,
        Key.D
    };

    private Key[] sequence;
    private int currentInput;
    private bool isRepairing;



    public override void StartRepair(Player player)
    {
        if (isRepairing)
            return;

        isRepairing = true;
        currentInput = 0;

        bool isClockwise = Random.value > 0.5f;

        sequence = isClockwise ? clockwise : counterClockwise;

        Debug.Log(
            isClockwise
                ? "Screw: tighten clockwise."
                : "Screw: loosen counter-clockwise."
        );
    }

    private void Update()
    {
        if (!isRepairing)
            return;

        CheckInput();
    }

    private void CheckInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
            CheckKey(Key.W);

        else if (Keyboard.current.aKey.wasPressedThisFrame)
            CheckKey(Key.A);

        else if (Keyboard.current.sKey.wasPressedThisFrame)
            CheckKey(Key.S);

        else if (Keyboard.current.dKey.wasPressedThisFrame)
            CheckKey(Key.D);
    }

    private void CheckKey(Key key)
    {
        if (key == sequence[currentInput])
        {
            currentInput++;

            Debug.Log($"Correct! {currentInput}/{sequence.Length}");

            if (currentInput >= sequence.Length)
            {
                CompleteRepair();
            }
        }
        else
        {
            Debug.Log("Wrong direction! Screw sequence reset.");
            currentInput = 0;
        }
    }

    private void CompleteRepair()
    {
        isRepairing = false;

        Debug.Log("SCREW REPAIR COMPLETED!");

        repairProgress.StartProgress();
    }
}