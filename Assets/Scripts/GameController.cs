using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    enum GameState { TITLE, HOW_TO_PLAY, MAIN_GAME, GAME_OVER, LEVEL_COMPLETE }

    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    public GameObject titleScreenPanel;
    public GameObject howToPlayPanel;
    public GameObject ingameOverlayPanel;
    public Text winText;
    public Text gameOverText;
    public Text pressKeyToContinueText;
    public GameObject sheriff;
    public GameObject despy;
    public double minHelpDisplayTimeInMs;

    GameState curGameState;
    double helpDisplayStartEpoch;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Start() {
        curGameState = GameState.TITLE;
        titleScreenPanel.SetActive(true);
        SetPlayersEnabled(false);
    }

    void Update() {
        if (curGameState.Equals(GameState.TITLE) && Input.anyKey) {
            titleScreenPanel.SetActive(false);
            howToPlayPanel.SetActive(true);
            curGameState = GameState.HOW_TO_PLAY;
            helpDisplayStartEpoch = Utils.Now();
        } else if (curGameState.Equals(GameState.HOW_TO_PLAY)
                    && (Utils.Now() - helpDisplayStartEpoch > minHelpDisplayTimeInMs)) {
            pressKeyToContinueText.enabled = true;
            if (Input.anyKey) {
                howToPlayPanel.SetActive(false);
                ingameOverlayPanel.SetActive(false);
                curGameState = GameState.MAIN_GAME;
                SetPlayersEnabled(true);
            }
        }
    }

    public void LevelComplete() {
        curGameState = GameState.LEVEL_COMPLETE;
        SetPlayersEnabled(false);
        ingameOverlayPanel.SetActive(true);
        winText.gameObject.SetActive(true);
    }

    public void GameOver() {
        curGameState = GameState.GAME_OVER;
        SetPlayersEnabled(false);
        ingameOverlayPanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetPlayersEnabled(bool enabled) {
        sheriff.GetComponent<PlayerController>().enabled = enabled;
        despy.GetComponent<PlayerController>().enabled = enabled;
    }

}
