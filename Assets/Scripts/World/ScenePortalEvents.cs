using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePortalEvents : MonoBehaviour {
    public void OnPortal() {
        PlayerController.Instance.SetCutscene(true);
    }

    public void setOverworldTransition() {
        SceneTransitionEvents.Instance.SetOverworldValues();
    }
}