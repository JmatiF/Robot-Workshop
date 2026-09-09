using UnityEngine;
using UnityEngine.InputSystem;

public class SoftwareRepairTask : RepairTask
{
    private Key[] sequence;
    private int currentInput;
    private bool isRepairing;

    [SerializeField] private WorkStation workStation;

    public override void StartRepair(Player player)
    {
        if (isRepairing)
            return;

        isRepairing = true;
        currentInput = 0;

        GenerateSequence();
        ShowSequence();
    }

    private void Update()
    {
        if (!isRepairing)
            return;

        CheckInput();
    }

    private void GenerateSequence()
    {
        sequence = new Key[6];

        Key[] availableKeys =
        {
            Key.W,
            Key.A,
            Key.S,
            Key.D
        };

        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = availableKeys[
                Random.Range(0, availableKeys.Length)
            ];
        }
    }

    private void ShowSequence()
    {
        repairUI.ShowSequence(sequence, currentInput);
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

            if (currentInput >= sequence.Length)
            {
                CompleteSequence();
            }
            else
            {
                ShowSequence();
            }
        }
        else
        {
            currentInput = 0;
        }
    }

    private void CompleteSequence()
    {
        isRepairing = false;

        repairUI.Hide();
        repairProgress.StartProgress();
    }
}