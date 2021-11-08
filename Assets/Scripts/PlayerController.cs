using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float MoveSpeed;
    public Transform Art;
    public Animator Anim;
    public LayerMask FloorMask;

    float getMovementAxis {
        get {
            float val = Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
            if (val < 0 && !facingLeft) {
                facingLeft = true;
            }
            if (val > 0 && facingLeft) {
                facingLeft = false;
            }
            return val;
        }
    }

    public bool facingLeft;

    private void Update() {
        Art.localScale = new Vector3(15f, 15f, facingLeft ? -15f : 15f);
        Anim.SetFloat("Movement", getMovementAxis);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0f, 5f, 0f), Vector3.down, out hit)) {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        transform.position += new Vector3(getMovementAxis * MoveSpeed, 0f, 0f) * Time.deltaTime;
    }
}