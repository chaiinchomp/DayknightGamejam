using UnityEngine.UI;
using UnityEngine;

public class UnlockController : MonoBehaviour {

    public Text winText;
    bool sheriffPresent;
    bool despyPresent;
    bool keyPresent;

    void Start() {
        winText.text = "";
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Sheriff")) {
            sheriffPresent = true;
        }
        if (other.gameObject.CompareTag("Despy")) {
            despyPresent = true;
        }
        if (other.gameObject.CompareTag("Key")) {
            keyPresent = true;
        }

        if (keyPresent && despyPresent && sheriffPresent) {
            winText.text = "MEOW YOU WIN";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Sheriff")) {
            sheriffPresent = false;
        }
        if (other.gameObject.CompareTag("Despy")) {
            despyPresent = false;
        }
        if (other.gameObject.CompareTag("Key")) {
            keyPresent = false;
        }
    }

}
