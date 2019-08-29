using UnityEngine;

public class CarController : MonoBehaviour {

    bool isMoving;
    Vector3 direction;

    void Update() {
        if (isMoving) {
            Vector3 possiblePosition = gameObject.transform.position + direction;
            transform.position = possiblePosition;
        }
    }

    public void StartMoving(Vector3 newDirection) {
        isMoving = true;
        direction = newDirection;
    }

}
