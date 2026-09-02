using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private SpriteRenderer carryingRenderer;
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private float movementOffset = 8f;
    [SerializeField] private float movementSpeed = 15f;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.localPosition;

        carryingRenderer.enabled = false;
    }

    private void Update()
    {
        HandleMovementVisual();
    }

    private void HandleMovementVisual()
    {
        if (body.linearVelocity.sqrMagnitude > 0.01f)
        {
            float rotation = Mathf.Sin(Time.time * movementSpeed) * movementOffset;

            transform.localRotation = Quaternion.Euler(0f, 0f, rotation);
        }
        else
        {
            transform.localRotation = Quaternion.identity;
        }
    }

    public void SetCarryingRobot(bool carrying)
    {
        playerRenderer.enabled = !carrying;
        carryingRenderer.enabled = carrying;
    }
}