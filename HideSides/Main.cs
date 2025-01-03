using KitchenMods;
using PreferenceSystem;

namespace KitchenHideSides
{
    internal class Main : IModInitializer
    {
        public const string MOD_GUID = "Chrystopher.PlateUp.HideSides";
        public const string MOD_NAME = "Hide Sides";
        public const string MOD_VERSION = "1.0.3";
        public const string MOD_AUTHOR = "Chrystopher";

        internal static PreferenceSystemManager PrefManager;

        internal const string HIDE_SIDES_ENABLED = "HideSidesEnabled";

        public void PostActivate(Mod mod)
        {
            Logger.LogInfo($"{MOD_GUID} v{MOD_VERSION} in use!");
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
    }
}