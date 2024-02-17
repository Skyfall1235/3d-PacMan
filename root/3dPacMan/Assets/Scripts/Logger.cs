////////////////////////////////////////////////
///Assignment/Lab/Project: PacMan - FROM PRIOR PROJECT
/////Name: Wyatt Murray
/////Section: SGD285.4147
/////Instructor: Aurore Locklear
/////Date: 1/21/24
////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Logger
{
    // Static methods for regular logging
    public static void LogMessage(string message)
    {
        Debug.Log(message);
    }
    public static void LogMessage(string message, GameObject sender)
    {
        LogMessage($"{sender} error: " + message);
    }

    // Static methods for logging warnings
    public static void LogWarning(string warning)
    {
        Debug.LogWarning(warning);
    }
    public static void LogWarning(string warning, GameObject sender)
    {
        LogWarning($"{sender} error: " + warning);
    }

    // Static methods for logging errors
    public static void LogError(string error)
    {
        Debug.LogError(error);
    }
    public static void LogError(string error, GameObject sender)
    {
        LogError($"{sender} error: "+error);
    }

    // Static methods for catching and logging exceptions
    public static void LogException(System.Exception exception)
    {
        Debug.LogError("Exception: " + exception.Message);
    }
    public static void LogException(System.Exception exception, GameObject sender)
    {
        Debug.LogError($"Exception from gameobject {sender}: " + exception.Message);
    }
}
