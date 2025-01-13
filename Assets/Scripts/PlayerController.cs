using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;


    // TODO: RIMUOVERE, SOLO PER TEST
    public GameData gameData;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI currencyText;


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

    private void Start() {
        // Carica la posizione del player
        gameData = SaveSystem.LoadGameData();

        if (gameData != null)
        {
            transform.position = new Vector3(gameData.position[0], gameData.position[1], gameData.position[2]);
            levelText.text = "Level: " + gameData.level;
            currencyText.text = "Currency: " + gameData.currency;
        } else {
            gameData = new GameData(1, 0, new int[] { 0, 0, 0 });
            transform.position = new Vector3(0, 0, 0);
            levelText.text = "Level: 1";
            currencyText.text = "Currency: 0";
        }
    }

    private void OnPlayerMove(Vector2 move)
    {
        moveInput = move;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)){
            gameData.level++;
        }
        if(Input.GetKeyDown(KeyCode.F2)){
            gameData.level--;
        }
        if(Input.GetKeyDown(KeyCode.F3)){
            gameData.currency++;
        }
        if(Input.GetKeyDown(KeyCode.F4)){
            gameData.currency--;
        }

        levelText.text = "Level: " + gameData.level;
        currencyText.text = "Currency: " + gameData.currency;
    }

    private void FixedUpdate()
    {
        if(moveInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
