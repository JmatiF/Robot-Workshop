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

    public void GenerateRandomProblems()
    {
        problems.Clear();

        int problemCount = Random.Range(1, 4);

        Problem[] availableProblems = (Problem[])System.Enum.GetValues(typeof(Problem));

        while (problems.Count < problemCount)
        {
            Problem randomProblem =
                availableProblems[Random.Range(0, availableProblems.Length)];

            if (!problems.Contains(randomProblem))
            {
                problems.Add(randomProblem);
            }
        }

        Debug.Log($"Robot problems: {string.Join(", ", problems)}");
    }

    public bool HasProblems()
    {
        return problems.Count > 0;
    }

    public List<Problem> GetProblems()
    {
        return problems;
    }
}