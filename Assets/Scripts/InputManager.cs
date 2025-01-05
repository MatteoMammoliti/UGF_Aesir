using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private InputActions inputActions;

    private void Awake()
    {
        // Singleton pattern (si assicura che esista solo un'istanza di InputManager)
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        inputActions = new InputActions();

        DontDestroyOnLoad(gameObject);

        // Initialize the input actions
        // Manda un evento PLAYER_MOVE quando il viene premuto il tasto per muoversi
        inputActions.Player.Move.performed += ctx => Messenger<Vector2>.Broadcast(GameEvent.PLAYER_MOVE, ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => Messenger<Vector2>.Broadcast(GameEvent.PLAYER_MOVE, Vector2.zero);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
