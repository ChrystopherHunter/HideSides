using KitchenLib;
using KitchenMods;
using PreferenceSystem;
using System;
using System.Reflection;

namespace KitchenHideSides
{
    internal class Main : BaseMod, IModSystem
    {
        public const string MOD_GUID = "Chrystopher.PlateUp.HideSides";
        public const string MOD_NAME = "Hide Sides";
        public const string MOD_VERSION = "1.0.1";
        public const string MOD_AUTHOR = "Chrystopher";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        internal static PreferenceSystemManager PrefManager;

        internal const string HIDE_SIDES_ENABLED = "HideSidesEnabled";

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected sealed override void OnPostActivate(Mod mod)
        {
            LogInfo($"{MOD_GUID} v{MOD_VERSION} in use!");
            CreatePreferences();
        }

        private static void CreatePreferences()
        {
            PrefManager = new PreferenceSystemManager(MOD_GUID, MOD_NAME);

            PrefManager
                .AddLabel("Hide Sides")
                .AddInfo("Hide side item orders for customers seated at metal tables?")
                .AddOption<bool>(
                    HIDE_SIDES_ENABLED,
                    false,
                    new bool[] { false, true },
                    new string[] { "Disabled", "Enabled" })
                .AddInfo("This setting can be toggled at any time and will take effect for the next customer order.");

            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.MainMenu);
            PrefManager.RegisterMenu(PreferenceSystemManager.MenuType.PauseMenu);
        }

        internal static void LogInfo(string _log) { Debug.Log($"{DateTime.Now} [{MOD_NAME}] " + _log); }
        internal static void LogWarning(string _log) { Debug.LogWarning($"{DateTime.Now} [{MOD_NAME}] " + _log); }
        internal static void LogError(string _log) { Debug.LogError($"{DateTime.Now} [{MOD_NAME}] " + _log); }
        internal static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        internal static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        internal static void LogError(object _log) { LogError(_log.ToString()); }
    }
}