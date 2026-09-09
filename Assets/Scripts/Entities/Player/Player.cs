using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.5f;
    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private PlayerUI playerUI;

    private Rigidbody2D body;
    private Vector2 moveInput;
    private InteractionArea currentInteraction;
    private Robot carriedRobot;

    private bool canMove = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInteraction();
        HandleMovementInput();
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        body.linearVelocity = moveInput * moveSpeed;
    }

    private void HandleInteraction()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        // Si está bloqueado, E lo desbloquea.
        if (!canMove)
        {
            SetMovementEnabled(true);
            return;
        }

        // Si puede moverse y hay una interacción disponible, E la inicia.
        if (currentInteraction != null)
        {
            SetMovementEnabled(false);
            currentInteraction.Interact();
        }
    }

    private void HandleMovementInput()
    {
        if (!canMove)
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = new Vector2(
            (Keyboard.current.dKey.isPressed ? 1 : 0) -
            (Keyboard.current.aKey.isPressed ? 1 : 0),
            (Keyboard.current.wKey.isPressed ? 1 : 0) -
            (Keyboard.current.sKey.isPressed ? 1 : 0)
        ).normalized;
    }

    public void SetInteraction(InteractionArea interaction)
    {
        currentInteraction = interaction;
    }

    public void ClearInteraction(InteractionArea interaction)
    {
        if (currentInteraction == interaction)
        {
            currentInteraction = null;
        }
    }

    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;

        if (!enabled)
        {
            moveInput = Vector2.zero;
            body.linearVelocity = Vector2.zero;
        }
    }

    public bool TakeRobot(Robot robot)
    {
        if (carriedRobot != null)
        {
            Debug.Log("Player is already carrying a robot.");
            return false;
        }

        carriedRobot = robot;

        robot.transform.SetParent(transform);
        robot.transform.localPosition = new Vector3(0f, 1f, 0f);

        playerVisual.SetCarryingRobot(true);
        playerUI.ShowRobotInfo(robot);

        return true;
    }

    public Robot GetCarriedRobot()
    {
        return carriedRobot;
    }

    public Robot TakeCarriedRobot()
    {
        Robot robot = carriedRobot;

        if (robot == null)
            return null;

        carriedRobot = null;

        robot.transform.SetParent(null);

        playerVisual.SetCarryingRobot(false);
        playerUI.HideRobotInfo();

        return robot;
    }
}