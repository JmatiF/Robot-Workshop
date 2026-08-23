using UnityEngine;
using UnityEngine.InputSystem;

public class RepairTask : MonoBehaviour
{
    private Key[] sequence;
    private int currentInput;
    private bool isRepairing;

    public void StartRepair(Player player)
    {
        if (isRepairing)
            return;

        isRepairing = true;
        currentInput = 0;

        GenerateSequence();
        ShowSequence();

        Debug.Log("Repair started!");
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
        string sequenceText = "Repair sequence: ";

        foreach (Key key in sequence)
        {
            sequenceText += key + " ";
        }

        Debug.Log(sequenceText);
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
            Debug.Log("Wrong input! Sequence reset.");
            currentInput = 0;
        }
    }

    private void CompleteRepair()
    {
        Debug.Log("REPAIR COMPLETED!");

        isRepairing = false;
    }
}