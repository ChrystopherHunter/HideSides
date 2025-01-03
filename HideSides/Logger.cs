using System;

namespace KitchenHideSides
{
    internal class Logger
    {
        internal static void LogInfo(string log) { Debug.Log($"{DateTime.Now} [{Main.MOD_NAME}] {log}"); }
        internal static void LogWarning(string log) { Debug.LogWarning($"{DateTime.Now} [{Main.MOD_NAME}] {log}"); }
        internal static void LogError(string log) { Debug.LogError($"{DateTime.Now} [{Main.MOD_NAME}] {log}"); }
        internal static void LogInfo(object log) { LogInfo(log.ToString()); }
        internal static void LogWarning(object log) { LogWarning(log.ToString()); }
        internal static void LogError(object log) { LogError(log.ToString()); }
    }
}
