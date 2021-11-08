using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {
    public static SceneSwitcher Instance;

    private void Awake() {
        Instance = this;
    }

    private void OnDestroy() {
        Instance = null;
    }

    public void SwapToTC() {
        FaderController.Instance.SwapToTC();
    }

    public void SwapToOverworld() {
        FaderController.Instance.SwaptoOverworld();
    }
}