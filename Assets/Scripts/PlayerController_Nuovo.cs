using UnityEngine;

public class PlayerController_Nuovo : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Vector2 moveInput;
    private bool jumpInput;
    private bool submit;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Jump.performed += ctx => jumpInput = true;
        inputActions.Player.Jump.canceled += ctx => jumpInput = false;

        inputActions.UI.Submit.performed += ctx => Submit();

        inputActions.Player.Switch.performed += ctx => {
            inputActions.Player.Disable();
            inputActions.UI.Enable();
            Debug.Log("Player -> UI");
        };

        inputActions.UI.Switch.performed += ctx => {
            inputActions.UI.Disable();
            inputActions.Player.Enable();
            Debug.Log("UI -> Player");
        };
    }

    private void OnEnable()
    {
        inputActions.Disable();
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {
        if (inputActions.Player.enabled)
        {
            Move();
            if (jumpInput)
            {
                Jump();
            }
        }
    }

    private void Move()
    {
        if(moveInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if(moveInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(moveDirection * moveSpeed * jumpForce * Time.deltaTime);
    }

    private void Submit()
    {
        Debug.Log("Submit");
    }
}
