using UnityEngine;

namespace BackboardMod {
    public class BackboardModifier : MonoBehaviour {
        KeyCode cachedKey;

        void Start() {
            if (!System.Enum.TryParse(BackboardMod.Settings.ToggleKey, out cachedKey)) {
                cachedKey = KeyCode.F10;
            }
        }

        void Update() {
            if (Input.GetKeyDown(cachedKey)) {
                ToggleOCBackboard();
            }
        }

        void ToggleOCBackboard() {
            var bg = GameObject.Find("OC Backboard");
            if (bg == null) {
                Debug.LogWarning("OC Backboard not found");
                return;
            }
            var renderer = bg.GetComponent<SpriteRenderer>();
            if (renderer != null) {
                renderer.enabled = !renderer.enabled;
            }
        }
    }
}
