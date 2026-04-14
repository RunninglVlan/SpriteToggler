using Modding;
using UnityEngine;

namespace BackboardMod {
    public class Settings {
        public string ToggleKey = "F10";
    }

    public class BackboardMod : Mod, IGlobalSettings<Settings> {
        public static Settings Settings { get; set; } = new();

        public BackboardMod() : base(nameof(BackboardMod)) { }
        public override string GetVersion() => "v1";

        public void OnLoadGlobal(Settings settings) => Settings = settings;
        public Settings OnSaveGlobal() => Settings;

        public override void Initialize() {
            var go = new GameObject(nameof(BackboardMod));
            go.AddComponent<BackboardModifier>();
            Object.DontDestroyOnLoad(go);
        }
    }
}
