using System.IO;
using UnityEngine;

public class GameLog : MonoBehaviour
{
    private string _fileName;

    private void Awake()
    {
        _fileName = Application.dataPath + "/LogFile.text";
        ClearLog();
    }

    private void Start()
    {
        Debug.Log("Game Started");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += WriteLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= WriteLog;
    }

    private void ClearLog()
    {
        File.WriteAllText(_fileName, string.Empty);
    }

    private void WriteLog(string logString, string stackTrace, LogType type)
    {
        TextWriter textwriter = new StreamWriter(_fileName, true);
        textwriter.WriteLine($"[{System.DateTime.Now} ] {logString}");
        textwriter.Close();
    }
}