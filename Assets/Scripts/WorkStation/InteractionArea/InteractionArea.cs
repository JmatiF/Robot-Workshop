using UnityEngine;

public interface IInteractable
{
    void Interact(Player player);
}

public class InteractionArea : MonoBehaviour
{
    private Player player;
    private IInteractable interactable;

    private void Awake()
    {
        MonoBehaviour[] components = GetComponentsInParent<MonoBehaviour>();

        foreach (MonoBehaviour component in components)
        {
            if (component is IInteractable)
            {
                interactable = component as IInteractable;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            player.SetInteraction(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.ClearInteraction(this);
            player = null;
        }
    }

    public void Interact()
    {
        if (interactable == null)
        {
            Debug.LogError("InteractionArea: No IInteractable found in parent.");
            return;
        }

        interactable.Interact(player);
    }
}