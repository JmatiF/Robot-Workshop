using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private BoxCollider2D interactionArea;
    [SerializeField] private RepairTask repairTask;

    public void Interact()
    {
        Debug.Log("Station interacted!");

        repairTask.StartRepair();
    }
}