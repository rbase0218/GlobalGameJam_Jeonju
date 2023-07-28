using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugWrap
{

    private readonly static string ErrorMsg = "가 존재하지 않습니다.";

#if UNITY_EDITOR_WIN
    public static string GetErrorMsg()
    {
        return ErrorMsg;
    }
#endif

#if UNITY_EDITOR_WIN
    public static void Log(object message) => Debug.Log(message);
#endif


#if UNITY_EDITOR_WIN
    public static void LogError(object message) => Debug.LogError(message);
#endif

#if UNITY_EDITOR_WIN
    public static void Assert(bool condition, object message) => Debug.Assert(condition, message);
    public static void Assert(bool condition) => Debug.Assert(condition);

#endif

#if UNITY_EDITOR_WIN
    public static void Break() => Debug.Break();
#endif
}
