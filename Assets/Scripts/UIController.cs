using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private static UIController instance;
    public static UIController Instance { get { return instance; } }

    public GameObject panel;
    public Text winText;
    public Text gameOverText;
    public GameObject sheriff;
    public GameObject despy;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    public void LevelComplete() {
        DisablePlayers();
        panel.SetActive(true);
        winText.text = "MEOW YOU WIN";
    }

    public void GameOver() {
        DisablePlayers();
        panel.SetActive(true);
        gameOverText.text = "Oh meow :( You lose";
    }

    void DisablePlayers() {
        sheriff.GetComponent<PlayerController>().enabled = false;
        despy.GetComponent<PlayerController>().enabled = false;
    }

}
