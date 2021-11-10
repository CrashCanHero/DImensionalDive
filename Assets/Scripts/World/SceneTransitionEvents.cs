using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionEvents : MonoBehaviour {
    public static SceneTransitionEvents Instance;
    StandardSceneTransitionManager manager;

    private void Awake() {
        Instance = this;
        manager = GetComponent<StandardSceneTransitionManager>();    
    }

    public void SetSceneSwitchValues() {
        manager.leaveSceneTransition.trigger = "SceneSwitch-FadeOut";
        manager.leaveSceneTransition.animationDuration = 2f;
        manager.leaveSceneTransition.minTransitionDuration = 3f;

        manager.enterSceneTransition.trigger = "SceneSwitch-FadeIn";
        manager.enterSceneTransition.animationDuration = 1f;
        manager.enterSceneTransition.minTransitionDuration = 3f;
    }

    public void SetOverworldValues() {
        manager.leaveSceneTransition.trigger = "Overworld-FadeOut";
        manager.leaveSceneTransition.animationDuration = 0.2f;
        manager.leaveSceneTransition.minTransitionDuration = 0.4f;

        manager.enterSceneTransition.trigger = "Overworld-FadeIn";
        manager.enterSceneTransition.animationDuration = 0.2f;
        manager.enterSceneTransition.minTransitionDuration = 0.4f;
    }
}