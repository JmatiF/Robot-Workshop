using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public enum Problem
    {
        LooseScrew,
        BrokenWire,
        BadBattery,
        Software
    }

    [SerializeField] private List<Problem> problems = new();

    public bool HasProblem(Problem problem)
    {
        return problems.Contains(problem);
    }

    public void RepairProblem(Problem problem)
    {
        if (!problems.Contains(problem))
            return;

        problems.Remove(problem);

        Debug.Log($"Problem repaired: {problem}");
    }

    public bool HasProblems()
    {
        return problems.Count > 0;
    }
}