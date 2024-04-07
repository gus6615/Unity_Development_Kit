using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static void EditorLog(LogType logType, string log)
    {
#if UNITY_EDITOR
        switch (logType)
        {
            case LogType.Log:
                Debug.Log(log);
                break;
            case LogType.Warning:
                Debug.LogWarning(log);
                break;
            case LogType.Error:
                Debug.LogError(log);
                break;
        }
#endif
    }
}
