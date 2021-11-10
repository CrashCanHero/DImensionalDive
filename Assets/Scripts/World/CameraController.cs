using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform Target;
    public Vector2 LevelBounds;
    public float MoveLimit;
    public float MoveSpeed;
    public float ZoomLevel = 10f;

    private void Update() {
        if (!Target) {
            return;
        }

        if (Mathf.Abs(Target.position.x - transform.position.x) > MoveLimit) {
            float moveDir = Target.position.x - transform.position.x;

            moveDir /= Mathf.Abs(moveDir);

            float moveTarget = moveDir * MoveLimit;

            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, transform.position.x + moveTarget, Mathf.Abs(Target.position.x - (transform.position.x + moveTarget)) / (1f / MoveSpeed)), transform.position.y, -ZoomLevel);
        }
    }

    private void LateUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LevelBounds.x, LevelBounds.y), transform.position.y, transform.position.z);
    }

    private void OnDrawGizmosSelected() {
        //Draw Level Bounds
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(LevelBounds.x, -10f), new Vector2(LevelBounds.x, 10f));
        Gizmos.DrawLine(new Vector2(LevelBounds.y, -10f), new Vector2(LevelBounds.y, 10f));

        //Draw Move Limits
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(transform.position.x - MoveLimit, transform.position.y), new Vector2(transform.position.x + MoveLimit, transform.position.y));

        //Draw Target Sphere
        if (Target) {
            Gizmos.color = Color.red;

            Vector2 adjustedPos = new Vector2(Mathf.Clamp(Target.position.x, transform.position.x - MoveLimit, transform.position.x + MoveLimit), transform.position.y);
            Gizmos.DrawSphere(adjustedPos, 0.1f);
        }
    }
}