using UnityEngine;

public class CarController : MonoBehaviour {

    public float viewOffsetX;
    public float viewOffsetY;

    bool isMoving;
    Vector3 direction;

    void Update() {
        if (isMoving) {
            MoveIfPossible();
        }
    }

    void MoveIfPossible() {
        Vector3 possiblePosition = gameObject.transform.position + direction;
        Collider2D objAtDestination = Physics2D.OverlapPoint(new Vector2(possiblePosition.x + viewOffsetX, possiblePosition.y + viewOffsetY));
        if (objAtDestination != null
            && objAtDestination.CompareTag("Crosswalk")
            && !objAtDestination.gameObject.GetComponent<CrosswalkController>().isPassable) {
            return;
        }

        transform.position = possiblePosition;
    }

    public void StartMoving(Vector3 newDirection) {
        isMoving = true;
        direction = newDirection;
    }

}
