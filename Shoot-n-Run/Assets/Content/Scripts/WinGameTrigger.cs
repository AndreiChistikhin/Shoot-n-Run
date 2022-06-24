using System;
using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{
    public static event Action<string> GameIsWon;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerMovement player))
            return;
        Debug.Log("Player Victory");
        GameIsWon?.Invoke("Выиграл");
    }
}
