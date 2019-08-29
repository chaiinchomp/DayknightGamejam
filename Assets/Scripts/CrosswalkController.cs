using UnityEngine;

public class CrosswalkController : MonoBehaviour {

    public GameObject redOverlaySprites;
    public GameObject greenOverlaySprites;
    public GameObject spawner1;
    public GameObject spawner2;

    public bool isPassable;

    void Start() {
        isPassable = true;
    }

    public void ToggleActive(bool buttonPressed) {
        isPassable = !buttonPressed;
        redOverlaySprites.SetActive(!buttonPressed);
        greenOverlaySprites.SetActive(buttonPressed);
        spawner1.SetActive(!buttonPressed);
        spawner2.SetActive(!buttonPressed);
    }
}
