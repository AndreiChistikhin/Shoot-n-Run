using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class WinGameTrigger : MonoBehaviour
{
    public static event Action GameIsFInished;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerMovement player))
            return;
        GameIsFInished?.Invoke();
        ReloadLevel().Forget();
    }

    private async UniTask ReloadLevel()
    {
        Debug.Log("Player Victory");
        await UniTask.Delay(3000);
        SceneManager.LoadScene("SampleScene");
    }
}
