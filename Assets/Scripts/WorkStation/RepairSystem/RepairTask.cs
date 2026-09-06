using UnityEngine;

public abstract class RepairTask : MonoBehaviour
{
    [SerializeField] protected RepairProgress repairProgress;
    [SerializeField] protected RepairUI repairUI;

    public abstract void StartRepair(Player player);
}