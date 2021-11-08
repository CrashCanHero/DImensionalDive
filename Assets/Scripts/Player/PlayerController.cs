using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance;
    public float MoveSpeed;
    public bool inCutscene;

    public Vector2 GetMovementAxis {
        get {
            if (inCutscene) {
                return Vector2.zero;
            }

            movementVec.x = Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
            movementVec.y = Mathf.Ceil(Input.GetAxisRaw("Vertical"));
            return movementVec;
        }
    }

    Vector2 movementVec;

    public virtual void Awake() {
        Instance = this;
    }

    public virtual void OnDestroy() {
        Instance = null;
    }

    public virtual void SetCutscene(bool enable) {
        inCutscene = enable;
    }
}