using TMPro;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;

    private void OnEnable()
    {
        WinGameTrigger.GameIsFInished += ShowWinInfo;
    }

    private void OnDisable()
    {
        WinGameTrigger.GameIsFInished -= ShowWinInfo;
    }

    private void ShowWinInfo()
    {
        _winText.gameObject.SetActive(true);
    }
}
