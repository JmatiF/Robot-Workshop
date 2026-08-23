using UnityEngine;

public class RepairProgress : MonoBehaviour
{
    [SerializeField] private float repairTime = 5f;
    [SerializeField] private WorkStation workStation;

    private float currentProgress;
    private bool isProcessing;

    public void StartProgress()
    {
        currentProgress = 0f;
        isProcessing = true;

        Debug.Log("Repair progress started.");
    }

    private void Update()
    {
        if (!isProcessing)
            return;

        currentProgress += Time.deltaTime;

        float percentage = currentProgress / repairTime * 100f;

        Debug.Log($"Repair progress: {percentage:F0}%");

        if (currentProgress >= repairTime)
        {
            CompleteProgress();
        }
    }

    private void CompleteProgress()
    {
        isProcessing = false;

        Debug.Log("Repair progress completed.");

        workStation.CompleteRepair();
    }
}