using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public static class Logger 
{
    public static bool canLog = true;
    public static bool CanLog { get => canLog;  set => canLog = value; }
    public static void LogMessage(bool canLog,string senderName,string message)
    {
        if(canLog == true)
        {
            Debug.Log($"From {senderName}: {message}");
        }
        else
        {
            return;
        }
    }
    public static void LogMessage(bool canLog,string message)
    {
        if (canLog == true)
        {
            Debug.Log($"{message}");
        }
        else
        {
            return;
        }
    }

}
