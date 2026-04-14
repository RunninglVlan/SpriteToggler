using System;
using Modding;
using UnityEngine;

namespace SpriteToggler {
    public class Settings {
        public string[] objectNames = ["OC Backboard"];
        public string toggleKey = "F10";
    }

    public class SpriteToggler() : Mod(nameof(SpriteToggler)), IGlobalSettings<Settings> {
        Settings settings = new();
        KeyCode toggleKey;

        public override string GetVersion() => "1.1.0.0";

        public void OnLoadGlobal(Settings value) {
            settings = value;
            if (!Enum.TryParse(settings.toggleKey, out toggleKey)) {
                toggleKey = KeyCode.F10;
            }
        }

        public Settings OnSaveGlobal() => settings;

        public override void Initialize() {
            ModHooks.HeroUpdateHook += OnUpdate;
            return;

            void OnUpdate() {
                if (!Input.GetKeyDown(toggleKey)) {
                    return;
                }
                ToggleSprites();
            }
        }

        void ToggleSprites() {
            foreach (string objectName in settings.objectNames) {
                var go = GameObject.Find(objectName);
                if (go == null) {
                    Log($"{objectName} not found");
                    return;
                }
                if (go.TryGetComponent<SpriteRenderer>(out var renderer)) {
                    renderer.enabled = !renderer.enabled;
                }
            }
        }
    }
}
