using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugWrap
{

    private readonly static string ErrorMsg = "�� �������� �ʽ��ϴ�.";

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
    public static string GetErrorMsg()
    {
        return ErrorMsg;
    }
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
    public static void Log(object message) => Debug.Log(message);
#endif


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
    public static void LogError(object message) => Debug.LogError(message);
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
    public static void Assert(bool condition, object message) => Debug.Assert(condition, message);
    public static void Assert(bool condition) => Debug.Assert(condition);

#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
    public static void Break() => Debug.Break();
#endif
}
