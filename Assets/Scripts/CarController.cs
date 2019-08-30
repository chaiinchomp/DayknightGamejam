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
        Collider2D[] objsAtDestination = Physics2D.OverlapPointAll(new Vector2(possiblePosition.x + viewOffsetX, possiblePosition.y + viewOffsetY));

        // Check for game over (player collision)
        GameObject player = Utils.GetObjectWithTag(objsAtDestination, "Player");
        if (player != null) {
            UIController.Instance.GameOver();
        }

        // Check for other collisions
        GameObject crosswalk = Utils.GetObjectWithTag(objsAtDestination, "Crosswalk");
        GameObject barrier = Utils.GetObjectWithTag(objsAtDestination, "CarBlocker");
        if ((crosswalk != null && !crosswalk.GetComponent<CrosswalkController>().isPassable) || (barrier != null)) {
            return;
        }

        transform.position = possiblePosition;
    }

    public void StartMoving(Vector3 newDirection) {
        isMoving = true;
        direction = newDirection;
    }

}
