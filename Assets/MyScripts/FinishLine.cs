using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private RoundManager roundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Finish line reached");
        if (roundManager != null) roundManager.CompleteLevel();
    }
}