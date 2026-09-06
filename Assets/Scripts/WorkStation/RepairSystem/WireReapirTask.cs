using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WireRepairTask : RepairTask
{
    private enum WireColor
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    private readonly List<WireColor> brokenWires = new();

    private string currentInput = "";
    private bool isRepairing;

    public override void StartRepair(Player player)
    {
        if (isRepairing)
            return;

        isRepairing = true;
        currentInput = "";

        GenerateBrokenWires();
        ShowBrokenWires();
    }

    private void Update()
    {
        if (!isRepairing)
            return;

        CheckInput();
    }

    private void GenerateBrokenWires()
    {
        brokenWires.Clear();

        int wireCount = Random.Range(1, 4);

        List<WireColor> availableColors = new()
        {
            WireColor.Red,
            WireColor.Green,
            WireColor.Blue,
            WireColor.Yellow
        };

        for (int i = 0; i < wireCount; i++)
        {
            int randomIndex = Random.Range(0, availableColors.Count);

            brokenWires.Add(availableColors[randomIndex]);
            availableColors.RemoveAt(randomIndex);
        }
    }

    private void ShowBrokenWires()
    {
        string result = "";

        foreach (WireColor wire in brokenWires)
        {
            result += GetWireLetter(wire) + " ";
        }

        repairUI.ShowText(result);
    }

    private void CheckInput()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        if (keyboard.rKey.wasPressedThisFrame)
            AddInput("R");

        else if (keyboard.gKey.wasPressedThisFrame)
            AddInput("G");

        else if (keyboard.bKey.wasPressedThisFrame)
            AddInput("B");

        else if (keyboard.yKey.wasPressedThisFrame)
            AddInput("Y");

        else if (keyboard.enterKey.wasPressedThisFrame)
            SubmitInput();
    }

    private void AddInput(string input)
    {
        currentInput += input;
    }

    private void SubmitInput()
    {
        string expectedInput = "";

        foreach (WireColor wire in brokenWires)
        {
            expectedInput += GetWireLetter(wire);
        }

        if (currentInput == expectedInput)
        {
            CompleteRepair();
        }
        else
        {
            currentInput = "";
        }
    }

    private string GetWireLetter(WireColor wire)
    {
        switch (wire)
        {
            case WireColor.Red:
                return "R";

            case WireColor.Green:
                return "G";

            case WireColor.Blue:
                return "B";

            case WireColor.Yellow:
                return "Y";

            default:
                return "";
        }
    }

    private void CompleteRepair()
    {
        isRepairing = false;

        repairUI.Hide();
        repairProgress.StartProgress();
    }
}