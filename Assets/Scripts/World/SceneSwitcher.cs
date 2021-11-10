using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {
    public static SceneSwitcher Instance;

    bool switching;

    private void Awake() {
        Instance = this;
    }

    private void OnDestroy() {
        Instance = null;
    }

    public void SwapToTC() {
        if (switching) {
            return;
        }
        SceneTransitionEvents.Instance.SetSceneSwitchValues();
        SaveSystem.LoadScene("TC");
        switching = true;
    }

    public void SwapToOverworld() {
        if (switching) {
            return;
        }
        SceneTransitionEvents.Instance.SetSceneSwitchValues();
        SaveSystem.LoadScene("Overworld - Dive Building - Interior");
        switching = true;
    }

    void SetTransitionValues() {

    }
}