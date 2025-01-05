using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;


    private Vector2 moveInput;

    private void Awake()
    {
        // Si mette in ascolto dell'evento PLAYER_MOVE
        Messenger<Vector2>.AddListener(GameEvent.PLAYER_MOVE, OnPlayerMove);
    }

    private void OnDestroy()
    {
        // Smette di ascoltare l'evento PLAYER_MOVE
        Messenger<Vector2>.RemoveListener(GameEvent.PLAYER_MOVE, OnPlayerMove);
    }

    private void OnPlayerMove(Vector2 move)
    {
        moveInput = move;
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(moveInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
