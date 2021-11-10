using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public bool FacingLeft;

    private void Start() {
        if (PlayerController.Instance.GetType() == typeof(OverworldPlayerController)) {
            OverworldPlayerController conn = (OverworldPlayerController)PlayerController.Instance;
            conn.SetFacing(FacingLeft);
        }
    }
}
