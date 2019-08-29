using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteToggle : MonoBehaviour {

    public GameObject redButtonSprite;
    public GameObject greenButtonSprite;

    public void ToggleActiveSprite(bool buttonPressed) {
        redButtonSprite.SetActive(!buttonPressed);
        greenButtonSprite.SetActive(buttonPressed);
    }

}
