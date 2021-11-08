using System.Collections;
using System.Collections.Generic;
using Toolnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderController : MonoBehaviour {
    public static FaderController Instance;
    Fader fader;

    IEnumerator fadeToScene(Vector2 pos, string newScene) {
        PlayerController.Instance.SetCutscene(true);
        fader.FadeOut();
        yield return new WaitForSeconds(2f);

        if (!string.IsNullOrEmpty(newScene)) {
            AsyncOperation op = SceneManager.LoadSceneAsync(newScene);

            while (!op.isDone) {
                yield return null;
            }
        }

        PlayerController.Instance.transform.position = pos;

        fader.FadeIn();

        yield return new WaitForSeconds(1f);

        PlayerController.Instance.SetCutscene(false);
    }

    private void Awake() {
        if (Instance) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        fader = GetComponent<Fader>();
    }

    public void FadeToScene(Vector2 PlayerPos, string newScene = "") {
        StartCoroutine(fadeToScene(PlayerPos, newScene));
    }

    public void SwapToTC() {
        FadeToScene(Vector2.zero, "TC");
    }

    public void SwaptoOverworld() {
        FadeToScene(new Vector2(7f, -3.8f), "Overworld");
    }
}
