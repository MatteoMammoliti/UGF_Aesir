using UnityEngine;

public class CheckpointController : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint reached!");
            SaveSystem.SavePosition(transform.position);
        }
    }
}
