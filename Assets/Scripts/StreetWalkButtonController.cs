using UnityEngine;

public class StreetWalkButtonController : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;
    public GameObject crosswalk;

    int pressCount;

    void Start() {
        pressCount = 0;
    }

    public void Press() {
        pressCount++;
        if (pressCount > 1) {
            // Button already pressed by other cat, don't change anything
            return;
        }
        TogglePressed(true);
    }

    public void Unpress() {
        pressCount--;
        if (pressCount > 0) {
            // Button still pressed by other cat, don't change anything
            return;
        }
        TogglePressed(false);
    }

    void TogglePressed(bool buttonPressed) {
        button1.GetComponent<ButtonSpriteToggle>().ToggleActiveSprite(buttonPressed);
        button2.GetComponent<ButtonSpriteToggle>().ToggleActiveSprite(buttonPressed);
        crosswalk.GetComponent<CrosswalkController>().ToggleActive(buttonPressed);
    }

}
