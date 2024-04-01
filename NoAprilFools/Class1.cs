using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace NoAprilFools
{
    public class NoAprilFools : ResoniteMod
    {
        public override string Name => "NoAprilFools";
        public override string Author => "Dante";
        public override string Version => "1.0.0";
        public override string Link => "none";

        public static ModConfiguration Config;

        public override void OnEngineInit()
        {
            Config = GetConfiguration();
            SetupMod();
        }

        static void SetupMod()
        {
            Harmony harmony = new Harmony("U-Dante.NoAprilFools");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Engine))]
        private static class EnginePatch
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Engine), "get_IsAprilFools")]
            private static bool IsAprilFoolsPrefix(ref bool __result)
            {
                __result = false;
                return false;
            }
        }
    }
}