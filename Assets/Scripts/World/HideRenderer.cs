using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRenderer : MonoBehaviour {
    public void Awake() {
        if (GetComponent<Renderer>()) {
            GetComponent<Renderer>().enabled = false;
        }
    }
}