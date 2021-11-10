using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPlayerController : PlayerController {
    public Vector2 MinLevelBounds, MaxLevelBounds;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneSwitcher.Instance.SwapToOverworld();
        }
        transform.position += (Vector3)GetMovementAxis * MoveSpeed * Time.deltaTime;
    }

    private void LateUpdate() {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, MinLevelBounds.x, MaxLevelBounds.x), Mathf.Clamp(transform.position.y, MinLevelBounds.y, MaxLevelBounds.y));
    }
}