using UnityEngine;

public class PlayerController : MonoBehaviour {

    MoveController moveController;

    void Start() {
        moveController = GetComponent<MoveController>();
    }

    void Update() {
        if (Input.GetButtonDown("Up")) {
            moveController.Move(Vector3.up);
        } else if (Input.GetButtonDown("Down")) {
            moveController.Move(Vector3.down);
        }
        if (Input.GetButtonDown("Left")) {
            moveController.Move(Vector3.left);
        } else if (Input.GetButtonDown("Right")) {
            moveController.Move(Vector3.right);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Key")) {
            other.transform.SetParent(gameObject.transform);
            other.transform.localPosition = new Vector3(0.25f,0.25f,0);
            other.transform.localScale = new Vector3(0.5f,0.5f,1);
        } else if (other.gameObject.CompareTag("Button")) {
            StreetWalkButtonController buttonController = other.gameObject.GetComponent<StreetWalkButtonController>();
            buttonController.Press();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Button")) {
            StreetWalkButtonController buttonController = other.gameObject.GetComponent<StreetWalkButtonController>();
            buttonController.Unpress();
        }
    }

}
