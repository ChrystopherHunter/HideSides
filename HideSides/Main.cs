using KitchenMods;
using PreferenceSystem;
using System;

namespace KitchenHideSides
{
    internal class Main : IModInitializer
    {
        public const string MOD_GUID = "Chrystopher.PlateUp.HideSides";
        public const string MOD_NAME = "Hide Sides";
        public const string MOD_VERSION = "1.0.2";
        public const string MOD_AUTHOR = "Chrystopher";

        internal static PreferenceSystemManager PrefManager;

        internal const string HIDE_SIDES_ENABLED = "HideSidesEnabled";

        public void PostActivate(Mod mod)
        {
            LogInfo($"{MOD_GUID} v{MOD_VERSION} in use!");
            CreatePreferences();
        }

        public void PreInject() { }

        public void PostInject() { }

        private static void CreatePreferences()
        {
            PrefManager = new PreferenceSystemManager(MOD_GUID, MOD_NAME);

            PrefManager
                .AddLabel("Hide Sides")
                .AddInfo("Hide side item orders for customers seated at metal tables?")
                .AddOption<bool>(
                    HIDE_SIDES_ENABLED,
                    false,
                    [false, true],
                    ["Disabled", "Enabled"])
                .AddInfo("This setting can be toggled at any time and will take effect for the next customer order.");

            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.MainMenu);
            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.PauseMenu);
        }

        internal static void LogInfo(string log) { Debug.Log($"{DateTime.Now} [{MOD_NAME}] " + log); }
        internal static void LogWarning(string log) { Debug.LogWarning($"{DateTime.Now} [{MOD_NAME}] " + log); }
        internal static void LogError(string log) { Debug.LogError($"{DateTime.Now} [{MOD_NAME}] " + log); }
        internal static void LogInfo(object log) { LogInfo(log.ToString()); }
        internal static void LogWarning(object log) { LogWarning(log.ToString()); }
        internal static void LogError(object log) { LogError(log.ToString()); }
    }
}