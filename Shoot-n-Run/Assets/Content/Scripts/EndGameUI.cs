using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameResultText;

    private void OnEnable()
    {
        WinGameTrigger.GameIsWon += ShowGameResultInfo;
        GameOverTrigger.GameIsLost += ShowGameResultInfo;
    }

    private void OnDisable()
    {
        WinGameTrigger.GameIsWon -= ShowGameResultInfo;
        GameOverTrigger.GameIsLost -= ShowGameResultInfo;
    }

    private void ShowGameResultInfo(string gameResult)
    {
        ReloadLevel().Forget();
        _gameResultText.gameObject.SetActive(true);
        _gameResultText.text = gameResult;
    }

    private async UniTask ReloadLevel()
    {
        await UniTask.Delay(3000);
        SceneManager.LoadScene("SampleScene");
    }
}