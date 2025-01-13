using UnityEngine;

public class CheckpointController : MonoBehaviour {

    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint reached!");
            playerController.gameData.position = new int[] { (int)transform.position.x, (int)transform.position.y, (int)transform.position.z };
            SaveSystem.SaveGameData(playerController.gameData);
        }
    }
}
