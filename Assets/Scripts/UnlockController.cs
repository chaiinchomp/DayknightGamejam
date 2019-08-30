using UnityEngine.UI;
using UnityEngine;

public class UnlockController : MonoBehaviour {

    int catsPresent;
    bool keyPresent;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            catsPresent++;
        } else if (other.gameObject.CompareTag("Key")) {
            keyPresent = true;
        }

        if (keyPresent && catsPresent == 2) {
            GameController.Instance.LevelComplete();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            catsPresent--;
        } else if (other.gameObject.CompareTag("Key")) {
            keyPresent = false;
        }
    }

}
