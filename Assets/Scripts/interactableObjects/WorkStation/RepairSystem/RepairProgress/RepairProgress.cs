using UnityEngine;

public class RepairProgress : MonoBehaviour
{
    [SerializeField] private float repairTime = 5f;
    [SerializeField] private WorkStation workStation;
    [SerializeField] private ProgressBar progressBar;

    private float currentProgress;
    private bool isProcessing;

    public void StartProgress()
    {
        currentProgress = 0f;
        isProcessing = true;

        progressBar.ResetProgress();
        progressBar.Show();

        Debug.Log("Repair progress started.");
    }

    private void Update()
    {
        if (!isProcessing)
            return;

        currentProgress += Time.deltaTime;

        float percentage = currentProgress / repairTime;

        progressBar.SetProgress(percentage);

        if (currentProgress >= repairTime)
        {
            CompleteProgress();
        }
    }

    private void CompleteProgress()
    {
        isProcessing = false;

        progressBar.SetProgress(1f);
        progressBar.Hide();

        Debug.Log("Repair progress completed.");

        workStation.CompleteRepair();
    }
}