using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : PlayerController {
    public Transform Art;
    public Animator Anim;
    public LayerMask FloorMask, WallMask;
    public float WallCheckDistance;

    ProximitySelector selector;

    public override void Awake() {
        base.Awake();
        selector = GetComponent<ProximitySelector>();
    }

    public bool facingLeft;

    private void Update() {

        if (GetMovementAxis.x < -0.1f && !facingLeft) {
            facingLeft = true;
        }

        if (GetMovementAxis.x > 0.1f && facingLeft) {
            facingLeft = false;
        }

        Art.localScale = new Vector3(15f, 15f, facingLeft ? -15f : 15f);
        Anim.SetFloat("Movement", GetMovementAxis.x);

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(0f, 5f), Vector2.down, 20f, FloorMask);

        if (hit) {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        float moveDir = GetMovementAxis.x * MoveSpeed;

        hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(0f, 1.5f), Vector2.right * GetMovementAxis.x, WallCheckDistance, WallMask);

        if (hit) {
            moveDir = 0f;
        }

        transform.position += new Vector3(moveDir, 0f, 0f) * Time.deltaTime;
    }

    public override void SetCutscene(bool enable) {
        base.SetCutscene(enable);
        selector.enabled = !enable;
    }
}