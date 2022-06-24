using System;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public static event Action<string> GameIsLost;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerMovement player))
            return;
        Debug.Log("Player Defeat");
        GameIsLost?.Invoke("Проиграл");
    }
}
