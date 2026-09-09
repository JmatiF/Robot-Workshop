using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform fill;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = fill.localScale;
        gameObject.SetActive(false);
    }

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);

        Vector3 scale = originalScale;
        scale.x *= progress;

        fill.localScale = scale;
    }

    public void ResetProgress()
    {
        fill.localScale = originalScale;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}