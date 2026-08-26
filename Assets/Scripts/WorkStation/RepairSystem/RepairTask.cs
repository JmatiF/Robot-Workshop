using UnityEngine;

public abstract class RepairTask : MonoBehaviour
{
    [SerializeField] protected RepairProgress repairProgress;

    public abstract void StartRepair(Player player);
}