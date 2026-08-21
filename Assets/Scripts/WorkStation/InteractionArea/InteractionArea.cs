using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    private Station station;

    private void Awake()
    {
        station = GetComponentInParent<Station>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.SetInteraction(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.ClearInteraction(this);
        }
    }

    public void Interact()
    {
        station.Interact();
    }
}